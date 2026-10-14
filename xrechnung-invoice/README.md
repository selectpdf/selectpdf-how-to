# Create an XRechnung invoice in C#

Create an XRechnung invoice in C#: convert the invoice to PDF/A-3 and embed the XRechnung XML as xrechnung.xml with AddZugferdInvoice, validated by veraPDF.

**Step-by-step guide:** https://selectpdf.com/how-to/xrechnung-invoice/

## Run it

```bash
dotnet run
```

The program writes `invoice-xrechnung.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- AccessibleXRechnung` | An accessible XRechnung invoice (PDF/A-3A with PDF/UA-1) ([AccessibleXRechnung.cs](AccessibleXRechnung.cs)) |
| `dotnet run --project variations -- ExistingPdfToXRechnung` | Turn an existing PDF invoice into an XRechnung invoice ([ExistingPdfToXRechnung.cs](ExistingPdfToXRechnung.cs)) |
| `dotnet run --project variations -- XRechnungWithCustomMetadata` | Add metadata of your own next to the invoice ([XRechnungWithCustomMetadata.cs](XRechnungWithCustomMetadata.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Electronic invoices](https://selectpdf.com/pdf-library/html/ElectronicInvoices.htm)
- [ZugferdProfile enumeration](https://selectpdf.com/pdf-library/html/T_SelectPdf_Universal_ZugferdProfile.htm)
- [PdfDocument.AddZugferdInvoice](https://selectpdf.com/pdf-library/html/M_SelectPdf_Universal_PdfDocument_AddZugferdInvoice_1.htm)
