# Generate an invoice PDF from an HTML template in C#

Generate invoice PDFs in C# from an HTML template and your data with SelectPdf.Universal: line items, totals, A4 margins, repeating table headers, page numbers.

**Step-by-step guide:** https://selectpdf.com/how-to/invoice-from-html-template/  
**Video walkthrough:** https://www.youtube.com/watch?v=3bS4cDjwU8Q  
**Short version:** https://www.youtube.com/shorts/xfh6fXDLcGM

## Run it

```bash
dotnet run
```

The program writes `invoice-2026-118.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- LongInvoice` | A long invoice: repeat the table header and number the pages ([LongInvoice.cs](LongInvoice.cs)) |
| `dotnet run --project variations -- TemplateFromFiles` | Keep the template and its stylesheet in files ([TemplateFromFiles.cs](TemplateFromFiles.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Convert HTML code to PDF](https://selectpdf.com/pdf-library/html/ConvertHtmlCodeToPdf.htm)
- [PDF page properties](https://selectpdf.com/pdf-library/html/PdfPageProperties.htm)
- [Repeat table headers](https://selectpdf.com/pdf-library/html/RepeatTableHeaders.htm)
