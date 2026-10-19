# Convert HTML to PDF asynchronously and in parallel in C#

Convert many pages to PDF at once in C#: async conversion with Task.WhenAll, a concurrency limit, timeouts and cancellation, batches with Parallel.ForEachAsync.

**Step-by-step guide:** https://selectpdf.com/how-to/async-parallel-html-to-pdf/  
**Video walkthrough:** https://www.youtube.com/watch?v=FdNhWTGaDec  
**Short version:** https://www.youtube.com/shorts/jgEAcxxcNE0

## Run it

```bash
dotnet run
```

The program writes `page-1.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- InvoiceBatch` | A long batch with Parallel.ForEachAsync ([InvoiceBatch.cs](InvoiceBatch.cs)) |
| `dotnet run --project variations -- KeepGoingOnErrors` | Keep going when one page fails ([KeepGoingOnErrors.cs](KeepGoingOnErrors.cs)) |
| `dotnet run --project variations -- RegionsAtOnce` | Render parts of one document at the same time ([RegionsAtOnce.cs](RegionsAtOnce.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Asynchronous conversion](https://selectpdf.com/pdf-library/html/AsyncConversion.htm)
- [Convert multiple URLs to PDF](https://selectpdf.com/pdf-library/html/ConvertMultipleUrlsToPdf.htm)
- [Conversion delay and timeout](https://selectpdf.com/pdf-library/html/ConversionDelay.htm)
