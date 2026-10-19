# HTML headers and footers with a logo and the date in C#

Add an HTML header with a logo and title and a footer with the date to each PDF page in C#, from an HTML string, a URL or an image, with SelectPdf.Universal.

**Step-by-step guide:** https://selectpdf.com/how-to/html-header-footer/  
**Video walkthrough:** https://www.youtube.com/watch?v=897HCvsnOvw  
**Short version:** https://www.youtube.com/shorts/yEo8kWoQnHQ

## Run it

```bash
dotnet run
```

The program writes `report.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- HeaderFromFile` | Load the header from an HTML file or URL ([HeaderFromFile.cs](HeaderFromFile.cs)) |
| `dotnet run --project variations -- ImageLogo` | Use a PNG logo with an image section ([ImageLogo.cs](ImageLogo.cs)) |
| `dotnet run --project variations -- FirstPageHeader` | A different header on the first page ([FirstPageHeader.cs](FirstPageHeader.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Headers and footers in HTML to PDF](https://selectpdf.com/pdf-library/html/HtmlToPdfHeadersAndFooters.htm)
- [PdfHtmlSection class](https://selectpdf.com/pdf-library/html/T_SelectPdf_Universal_PdfHtmlSection.htm)
- [PDF templates](https://selectpdf.com/pdf-library/html/PdfTemplates.htm)
