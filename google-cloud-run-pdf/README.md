# HTML to PDF on Google Cloud Run in C#

Convert HTML to PDF in an ASP.NET Core container on Google Cloud Run: packages and fonts, a Dockerfile with the non-root user, and the gcloud deploy settings.

**Step-by-step guide:** https://selectpdf.com/how-to/google-cloud-run-pdf/  
**Video walkthrough:** https://www.youtube.com/watch?v=hhkvdEI0iQk  
**Short version:** https://www.youtube.com/shorts/u6AniaRr5Ac

## Run it

```bash
dotnet run

# then open the address dotnet run prints, followed by /report.pdf
```

The request returns `report.pdf`. Requires the .NET 10 SDK. Deployment steps: https://selectpdf.com/how-to/google-cloud-run-pdf/#deploy

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Deployment to Google Cloud Run](https://selectpdf.com/pdf-library/html/Google-Cloud-Run.htm)
- [Deployment with Docker](https://selectpdf.com/pdf-library/html/Deployment-Docker.htm)
- [Fonts and languages](https://selectpdf.com/pdf-library/html/Fonts-And-Languages.htm)
- [Docker deployment compared across ten .NET PDF libraries](https://selectpdf.com/comparisons/csharp-pdf-libraries/#standards)
