using System.Threading.Channels;
using SelectPdf.Universal;

static class RetryFailedJobs
{
    public static async Task Run()
    {
        var queue = Channel.CreateUnbounded<(string Url, string File)>();
        queue.Writer.TryWrite(("https://selectpdf.com/downloads/", "downloads.pdf"));
        queue.Writer.TryWrite(("https://unknown-host.invalid", "unknown.pdf"));
        queue.Writer.Complete();

        await foreach (var (url, file) in queue.Reader.ReadAllAsync())
        {
            // up to 3 attempts per job, each with its own time limit; a failed job does not stop the worker
            for (int attempt = 1; ; attempt++)
            {
                using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(60));
                try
                {
                    HtmlToPdf converter = new HtmlToPdf();
                    PdfDocument doc = await converter.ConvertUrlAsync(url, timeout.Token);
                    doc.Save(file);
                    doc.Close();
                    Console.WriteLine($"{url}: saved {file}");
                    break;
                }
                catch (Exception ex) when (attempt < 3)
                {
                    Console.WriteLine($"{url}: attempt {attempt} failed ({ex.Message}), retrying");
                    await Task.Delay(TimeSpan.FromSeconds(attempt));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{url}: failed after {attempt} attempts ({ex.Message})");
                    break;
                }
            }
        }
    }
}
