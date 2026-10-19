# Add page numbers to a PDF in C# (Page X of Y)

Add "Page X of Y" page numbers to PDFs in C#: in an HTML to PDF footer, skipped on a cover page, or stamped onto an existing PDF with SelectPdf.Universal.

**Step-by-step guide:** https://selectpdf.com/how-to/footer-page-numbers/  
**Video walkthrough:** https://www.youtube.com/watch?v=qYrLg6UCaXU  
**Short version:** https://www.youtube.com/shorts/fOOdfU7HHMY

## Run it

```bash
dotnet run
```

The program writes `report.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- SkipCoverPage` | Skip the header and footer on a cover page ([SkipCoverPage.cs](SkipCoverPage.cs)) |
| `dotnet run --project variations -- NumberExistingPdf` | Add page numbers to an existing PDF ([NumberExistingPdf.cs](NumberExistingPdf.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Headers and footers in HTML to PDF](https://selectpdf.com/pdf-library/html/HtmlToPdfHeadersAndFooters.htm)
- [Headers and footers on existing PDFs](https://selectpdf.com/pdf-library/html/ExistingPdfHeadersAndFooters.htm)
- [PDF templates](https://selectpdf.com/pdf-library/html/PdfTemplates.htm)
