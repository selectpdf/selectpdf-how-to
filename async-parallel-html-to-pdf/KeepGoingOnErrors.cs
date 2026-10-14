using SelectPdf.Universal;

static class KeepGoingOnErrors
{
    public static async Task Run()
    {
        string[] urls = ["https://selectpdf.com", "https://unknown-host.invalid", "https://selectpdf.com/pricing/"];

        // one task per page that never throws: a failed or slow page is reported, the rest are saved
        var results = await Task.WhenAll(urls.Select(async url =>
        {
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(60));   // per page
            try
            {
                HtmlToPdf converter = new HtmlToPdf();
                return (url, doc: await converter.ConvertUrlAsync(url, timeout.Token), error: (string?)null);
            }
            catch (OperationCanceledException)
            {
                return (url, doc: (PdfDocument?)null, error: "timed out");
            }
            catch (Exception ex)
            {
                return (url, doc: (PdfDocument?)null, error: ex.Message);
            }
        }));

        for (int i = 0; i < results.Length; i++)
        {
            var (url, doc, error) = results[i];
            if (doc is null) { Console.WriteLine($"{url}: {error}"); continue; }
            doc.Save($"result-{i + 1}.pdf");
            doc.Close();
        }
    }
}
