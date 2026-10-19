# HTML to PDF on ARM64 Linux (AWS Graviton) in C#

Convert HTML to PDF in C# on ARM64 Linux, such as AWS Graviton, with SelectPdf.Universal: the linux-arm64 engine package and an ARM64 Docker image, no apt-get.

**Step-by-step guide:** https://selectpdf.com/how-to/html-to-pdf-arm64/  
**Video walkthrough:** https://www.youtube.com/watch?v=ozfdPPNQzlg  
**Short version:** https://www.youtube.com/shorts/B0_eCOLHB00

## Run it

```bash
dotnet run

# or in a container on an ARM64 machine (writes label.pdf to ./out):
docker build --platform linux/arm64 -t label-pdf .
docker run --rm --platform linux/arm64 -v "$PWD/out:/out" -w /out label-pdf
```

The program writes `label.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Deployment with Docker: Linux ARM64](https://selectpdf.com/pdf-library/html/Deployment-Docker.htm)
- [Installation: the engine packages](https://selectpdf.com/pdf-library/html/Installation.htm)
- [Amazon Web Services](https://selectpdf.com/pdf-library/html/Amazon-Web-Services.htm)
- [Docker deployment compared across ten .NET PDF libraries](https://selectpdf.com/comparisons/csharp-pdf-libraries/#standards)
