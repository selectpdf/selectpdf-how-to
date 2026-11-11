# Fix HTML to PDF on Alpine Linux in C# with the remote engine

On Alpine (musl), SelectPdf converts through the selectpdf/engine container: the native engines need glibc, so the app references no native package and sets `RenderingEngine.ChromiumRemote`.

**Step-by-step guide:** https://selectpdf.com/how-to/troubleshoot-alpine/  
**Video walkthrough:** https://www.youtube.com/watch?v=iemvGbbdyjU  
**Short version:** https://www.youtube.com/shorts/UCwLJaRHuKQ

## Run it

```bash
export SELECTPDF_ENGINE_TOKEN=$(openssl rand -base64 32)
docker compose run --rm app        # writes report.pdf to ./out
docker compose down
```

The program writes `report.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Remote engine](https://selectpdf.com/pdf-library/html/Remote-Engine.htm)
- [Deployment with Docker](https://selectpdf.com/pdf-library/html/Deployment-Docker.htm)
- [GlobalProperties.RenderingEngine](https://selectpdf.com/pdf-library/html/P_SelectPdf_Universal_GlobalProperties_RenderingEngine.htm)
