# HTML to PDF in C#: convert a URL or an HTML string

Convert a web page URL or an HTML string to PDF in C# on .NET 8 or .NET 10, with A4 pages and 20 mm margins, on Windows, Linux and macOS, step by step.

**Step-by-step guide:** https://selectpdf.com/how-to/html-to-pdf-csharp/  
**Video walkthrough:** https://www.youtube.com/watch?v=e_6Z0LBRPGk  
**Short version:** https://www.youtube.com/shorts/u7SVfl063DI

## Run it

```bash
dotnet run
```

The program writes `webpage.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- PrintStylesheet` | Use the page's print stylesheet ([PrintStylesheet.cs](PrintStylesheet.cs)) |
| `dotnet run --project variations -- WaitForJavaScript` | Wait for content that JavaScript adds ([WaitForJavaScript.cs](WaitForJavaScript.cs)) |
| `dotnet run --project variations -- ConvertAsync` | Convert asynchronously, with a timeout ([ConvertAsync.cs](ConvertAsync.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Convert a URL to PDF](https://selectpdf.com/pdf-library/html/ConvertUrlToPdf.htm)
- [Convert an HTML string to PDF](https://selectpdf.com/pdf-library/html/ConvertHtmlCodeToPdf.htm)
- [Conversion delay and timeout](https://selectpdf.com/pdf-library/html/ConversionDelay.htm)
