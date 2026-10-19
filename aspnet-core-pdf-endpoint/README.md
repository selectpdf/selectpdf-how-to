# Return a PDF from an ASP.NET Core endpoint in C#

Return HTML rendered as a PDF download from an ASP.NET Core minimal API endpoint in C#, asynchronously, and render Razor components such as invoices to PDF.

**Step-by-step guide:** https://selectpdf.com/how-to/aspnet-core-pdf-endpoint/  
**Video walkthrough:** https://www.youtube.com/watch?v=XL4UKSA4uIU  
**Short version:** https://www.youtube.com/shorts/k3CRK42k58A

## Run it

```bash
dotnet run

# in a second terminal, with the address dotnet run prints:
curl -X POST http://localhost:5000/pdf -H "Content-Type: application/json" \
     -d '{"html":"<h1>Quote #2207</h1>"}' -o document.pdf
```

The request returns `document.pdf`. Requires the .NET 10 SDK.

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- RazorInvoice` | Render a Razor component, such as an invoice, to PDF ([RazorInvoice.cs](RazorInvoice.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Asynchronous conversion](https://selectpdf.com/pdf-library/html/AsyncConversion.htm)
- [Security recommendations](https://selectpdf.com/pdf-library/html/Security-Recommendations.htm)
- [Convert an HTML string to PDF](https://selectpdf.com/pdf-library/html/ConvertHtmlCodeToPdf.htm)
