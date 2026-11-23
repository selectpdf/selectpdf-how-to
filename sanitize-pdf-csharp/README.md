# Sanitize a PDF from an untrusted source in C#

Sanitize uploaded PDFs in C#: scan for JavaScript, embedded files and actions, then refuse the file, clean it or rasterize every page with PdfSanitizeManager.

**Step-by-step guide:** https://selectpdf.com/how-to/sanitize-pdf-csharp/  
**Video walkthrough:** https://www.youtube.com/watch?v=TdHwfjIGV7Y  
**Short version:** https://www.youtube.com/shorts/fzT1Ij4UkGI

## Run it

```bash
dotnet run
```

The program writes `sanitized.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- RefuseActiveContent` | Refuse an upload instead of cleaning it ([RefuseActiveContent.cs](RefuseActiveContent.cs)) |
| `dotnet run --project variations -- RasterizePages` | Rasterize: keep only the look of the pages ([RasterizePages.cs](RasterizePages.cs)) |
| `dotnet run --project variations -- StrictOptions` | Also remove web links and metadata ([StrictOptions.cs](StrictOptions.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Sanitize PDF documents from untrusted sources](https://selectpdf.com/pdf-library/html/PdfSanitize.htm)
- [PdfSanitizeManager class](https://selectpdf.com/pdf-library/html/T_SelectPdf_Universal_PdfSanitizeManager.htm)
- [PdfSanitizeOptions enumeration](https://selectpdf.com/pdf-library/html/T_SelectPdf_Universal_PdfSanitizeOptions.htm)
