# Free HTML to PDF in C# with the SelectPdf Community Edition

Convert HTML to PDF in C# for free with the SelectPdf Community Edition on Windows, Linux, macOS and Docker: setup, headers and footers, and the 5-page limit.

**Step-by-step guide:** https://selectpdf.com/how-to/community-edition-setup/  
**Video walkthrough:** https://www.youtube.com/watch?v=vH1GbRgFiOk  
**Short version:** https://www.youtube.com/shorts/K1AkVHL725o

## Run it

```bash
dotnet run
```

The program writes `community-edition.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Community Edition](https://selectpdf.com/community-edition/)
- [Convert URL to PDF](https://selectpdf.com/pdf-library/html/ConvertUrlToPdf.htm)
- [Installation](https://selectpdf.com/pdf-library/html/Installation.htm)
