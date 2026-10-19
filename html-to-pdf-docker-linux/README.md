# HTML to PDF in Docker on Linux with C# (no apt-get)

Convert HTML to PDF in a Linux Docker container with SelectPdf.Universal: two NuGet packages, a stock .NET runtime image, and no system packages to install.

**Step-by-step guide:** https://selectpdf.com/how-to/html-to-pdf-docker-linux/  
**Video walkthrough:** https://www.youtube.com/watch?v=a0tevSFNVlA  
**Short version:** https://www.youtube.com/shorts/YC7ngpM8_oA

## Run it

```bash
dotnet run

# or in the container (writes invoice.pdf to ./out):
docker build -t invoice-pdf .
docker run --rm -v "$PWD/out:/out" -w /out invoice-pdf
```

The program writes `invoice.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Deployment with Docker](https://selectpdf.com/pdf-library/html/Deployment-Docker.htm)
- [Remote engine](https://selectpdf.com/pdf-library/html/Remote-Engine.htm)
- [Fonts and languages](https://selectpdf.com/pdf-library/html/Fonts-And-Languages.htm)
- [Cloud deployments](https://selectpdf.com/pdf-library/html/Cloud-Deployments.htm)
- [Docker deployment compared across ten .NET PDF libraries](https://selectpdf.com/comparisons/csharp-pdf-libraries/#standards)
