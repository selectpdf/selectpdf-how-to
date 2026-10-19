# Generate and download a PDF from Blazor in C#

Generate a PDF on the server from a Blazor Web App in C# and download it with a link or a JS interop stream, using a Razor component as the template.

**Step-by-step guide:** https://selectpdf.com/how-to/blazor-pdf-download/  
**Video walkthrough:** https://www.youtube.com/watch?v=HKvGFv4Tluo  
**Short version:** https://www.youtube.com/shorts/utnfKVF63j4

## Run it

```bash
dotnet run
```

The request returns `report.pdf`. Requires the .NET 10 SDK.

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- ComponentReport` | Use a Razor component as the PDF template ([ComponentReport.cs](ComponentReport.cs)) |
| `dotnet run --project variations -- StreamDownload` | Stream the PDF through JS interop, with the button disabled while it converts ([StreamDownload.cs](StreamDownload.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Asynchronous conversion](https://selectpdf.com/pdf-library/html/AsyncConversion.htm)
- [Convert an HTML string to PDF](https://selectpdf.com/pdf-library/html/ConvertHtmlCodeToPdf.htm)
- [Security recommendations](https://selectpdf.com/pdf-library/html/Security-Recommendations.htm)
