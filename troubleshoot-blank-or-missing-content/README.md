# Fix blank pages and missing content in HTML to PDF (C#)

Fix blank or incomplete PDFs from HTML in C#: wait for script content, start the conversion from JavaScript, resolve relative images and use print CSS.

**Step-by-step guide:** https://selectpdf.com/how-to/troubleshoot-blank-or-missing-content/

## Run it

```bash
dotnet run
```

The program writes `report.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- StartFromJavaScript` | Let the page start the conversion ([StartFromJavaScript.cs](StartFromJavaScript.cs)) |
| `dotnet run --project variations -- PrintStyles` | Render with the print styles ([PrintStyles.cs](PrintStyles.cs)) |
| `dotnet run --project variations -- WideContent` | Keep wide content instead of cutting it ([WideContent.cs](WideContent.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Troubleshooting](https://selectpdf.com/pdf-library/html/Troubleshooting.htm)
- [Conversion delay and web page timeout](https://selectpdf.com/pdf-library/html/ConversionDelay.htm)
- [Start conversion from JavaScript](https://selectpdf.com/pdf-library/html/ConvertFromJs.htm)
