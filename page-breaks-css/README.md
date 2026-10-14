# Control page breaks in HTML to PDF with CSS

Control where pages break when you convert HTML to PDF in C#: page-break-before, page-break-after and page-break-inside in CSS, plus breaks from @media print.

**Step-by-step guide:** https://selectpdf.com/how-to/page-breaks-css/

## Run it

```bash
dotnet run
```

The program writes `report.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- KeepTogether` | Keep a block together on one page ([KeepTogether.cs](KeepTogether.cs)) |
| `dotnet run --project variations -- PrintStylesheet` | Page breaks only in the print stylesheet ([PrintStylesheet.cs](PrintStylesheet.cs)) |
| `dotnet run --project variations -- RepeatTableHeaders` | Repeat table headers on every page ([RepeatTableHeaders.cs](RepeatTableHeaders.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Page breaks](https://selectpdf.com/pdf-library/html/PageBreaks.htm)
- [Media types](https://selectpdf.com/pdf-library/html/MediaTypes.htm)
- [Convert HTML code to PDF](https://selectpdf.com/pdf-library/html/ConvertHtmlCodeToPdf.htm)
- [Repeat table headers](https://selectpdf.com/pdf-library/html/RepeatTableHeaders.htm)
