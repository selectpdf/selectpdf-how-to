# HTML to PDF on Azure App Service (Linux) in C#

Convert HTML to PDF in an ASP.NET Core app on Azure App Service for Linux: which plan to use, the packages and fonts it needs, and zip deployment.

**Step-by-step guide:** https://selectpdf.com/how-to/azure-app-service-linux/  
**Video walkthrough:** https://www.youtube.com/watch?v=xBHQ9Z2qXpM  
**Short version:** https://www.youtube.com/shorts/h--u8miXgSM

## Run it

```bash
dotnet run

# then open the address dotnet run prints, followed by /report.pdf
```

The request returns `report.pdf`. Requires the .NET 10 SDK. Deployment steps: https://selectpdf.com/how-to/azure-app-service-linux/#deploy

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Deployment to Azure App Service](https://selectpdf.com/pdf-library/html/Azure-App-Service.htm)
- [Fonts and languages](https://selectpdf.com/pdf-library/html/Fonts-And-Languages.htm)
- [Microsoft Azure](https://selectpdf.com/pdf-library/html/SelectPdf-Microsoft-Azure.htm)
