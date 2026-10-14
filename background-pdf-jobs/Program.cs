using System.Threading.Channels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SelectPdf.Universal;

// the queue is a singleton: the app writes jobs, the background worker reads them
var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton(Channel.CreateUnbounded<PdfJob>());
builder.Services.AddHostedService<PdfWorker>();
using IHost host = builder.Build();
await host.StartAsync();

// queue a few jobs: writing returns at once, the worker converts them in the background
var queue = host.Services.GetRequiredService<Channel<PdfJob>>();
await queue.Writer.WriteAsync(new PdfJob("invoice-1001.pdf", Html: "<h1>Invoice #1001</h1><p>Annual license</p>"));
await queue.Writer.WriteAsync(new PdfJob("pricing.pdf", Url: "https://selectpdf.com/pricing/"));
await queue.Writer.WriteAsync(new PdfJob("invoice-1002.pdf", Html: "<h1>Invoice #1002</h1><p>Priority support</p>"));

// no more jobs: the worker finishes the queue, then stops the application
queue.Writer.Complete();
await host.WaitForShutdownAsync();

record PdfJob(string File, string? Html = null, string? Url = null);

class PdfWorker(Channel<PdfJob> queue, IHostApplicationLifetime lifetime) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // one job at a time, until the queue is completed and empty, or the host stops
        await foreach (PdfJob job in queue.Reader.ReadAllAsync(stoppingToken))
        {
            // a converter per job; the stopping token cancels a conversion still running
            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument doc = job.Url is not null
                ? await converter.ConvertUrlAsync(job.Url, stoppingToken)
                : await converter.ConvertHtmlStringAsync(job.Html!, stoppingToken);
            doc.Save(job.File);
            doc.Close();
            Console.WriteLine($"saved {job.File}");
        }

        // in this sample the queue is completed once all jobs are in, so stop the application
        lifetime.StopApplication();
    }
}
