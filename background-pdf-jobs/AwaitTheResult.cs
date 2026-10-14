using System.Threading.Channels;
using SelectPdf.Universal;

record StatementJob(string Html, string File, TaskCompletionSource<string> Done);

static class AwaitTheResult
{
    public static async Task Run()
    {
        var queue = Channel.CreateUnbounded<StatementJob>();

        // the worker completes each job's TaskCompletionSource with the file, or with the error
        Task worker = Task.Run(async () =>
        {
            await foreach (StatementJob job in queue.Reader.ReadAllAsync())
            {
                try
                {
                    HtmlToPdf converter = new HtmlToPdf();
                    PdfDocument doc = await converter.ConvertHtmlStringAsync(job.Html);
                    doc.Save(job.File);
                    doc.Close();
                    job.Done.SetResult(Path.GetFullPath(job.File));
                }
                catch (Exception ex)
                {
                    job.Done.SetException(ex);
                }
            }
        });

        // the caller queues a job and awaits its own result
        var job = new StatementJob("<h1>Statement for October</h1><p>Balance: 0.00</p>", "statement.pdf",
            new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously));
        await queue.Writer.WriteAsync(job);
        string file = await job.Done.Task;
        Console.WriteLine($"ready: {file}");

        queue.Writer.Complete();
        await worker;
    }
}
