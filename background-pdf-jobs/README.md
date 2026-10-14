# Generate PDFs in a background queue in .NET (BackgroundService)

Queue HTML and URL to PDF jobs in a .NET app and convert them in a BackgroundService: a Channel as the job queue, async conversion and a clean shutdown.

**Step-by-step guide:** https://selectpdf.com/how-to/background-pdf-jobs/

## Run it

```bash
dotnet run
```

The program writes `pricing.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- SeveralWorkers` | Several workers on one queue ([SeveralWorkers.cs](SeveralWorkers.cs)) |
| `dotnet run --project variations -- AwaitTheResult` | Let the caller await its own job ([AwaitTheResult.cs](AwaitTheResult.cs)) |
| `dotnet run --project variations -- RetryFailedJobs` | Retry a failed job, then move on ([RetryFailedJobs.cs](RetryFailedJobs.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Asynchronous conversion](https://selectpdf.com/pdf-library/html/AsyncConversion.htm)
- [HtmlToPdf.ConvertUrlAsync(String, CancellationToken)](https://selectpdf.com/pdf-library/html/M_SelectPdf_Universal_HtmlToPdf_ConvertUrlAsync.htm)
- [HtmlToPdf.ConvertHtmlStringAsync(String, CancellationToken)](https://selectpdf.com/pdf-library/html/M_SelectPdf_Universal_HtmlToPdf_ConvertHtmlStringAsync_2.htm)
