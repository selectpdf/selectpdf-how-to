# HTML to PDF in Azure Functions with C#

Generate PDFs from HTML in an Azure Functions HTTP trigger with C#: the isolated worker, the plans that work, the Linux and Windows packages, deployment.

**Step-by-step guide:** https://selectpdf.com/how-to/azure-functions-html-to-pdf/

## Run it

```bash
func start

# in a second terminal (the local host does not ask for function keys):
curl "http://localhost:7071/api/Invoice?number=1042" -o invoice.pdf
```

The request returns `invoice.pdf`. Requires the .NET 10 SDK. Deployment steps: https://selectpdf.com/how-to/azure-functions-html-to-pdf/#deploy

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Deployment to Azure Functions](https://selectpdf.com/pdf-library/html/Azure-Functions.htm)
- [Deployment to Azure App Service](https://selectpdf.com/pdf-library/html/Azure-App-Service.htm)
- [Fonts and languages](https://selectpdf.com/pdf-library/html/Fonts-And-Languages.htm)
