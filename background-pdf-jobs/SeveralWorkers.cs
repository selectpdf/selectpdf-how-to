using System.Threading.Channels;
using SelectPdf.Universal;

static class SeveralWorkers
{
    public static async Task Run()
    {
        Directory.CreateDirectory("reports");

        // a bounded queue: when it holds 10 jobs, WriteAsync waits until a worker takes one
        var queue = Channel.CreateBounded<int>(10);

        // three workers read the same queue; each job goes to one of them
        Task[] workers = Enumerable.Range(1, 3).Select(worker => Task.Run(async () =>
        {
            await foreach (int number in queue.Reader.ReadAllAsync())
            {
                HtmlToPdf converter = new HtmlToPdf();
                PdfDocument doc = await converter.ConvertHtmlStringAsync(
                    $"<h1>Report {number}</h1><p>Converted by worker {worker}.</p>");
                doc.Save(Path.Combine("reports", $"report-{number}.pdf"));
                doc.Close();
            }
        })).ToArray();

        for (int number = 1; number <= 12; number++)
            await queue.Writer.WriteAsync(number);

        queue.Writer.Complete();
        await Task.WhenAll(workers);
    }
}
