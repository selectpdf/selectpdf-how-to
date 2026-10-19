# Create a ZUGFeRD / Factur-X invoice in C#

Create a ZUGFeRD / Factur-X hybrid invoice in C#: convert HTML to PDF/A-3 and embed the CII XML with AddZugferdInvoice and the right profile.

**Step-by-step guide:** https://selectpdf.com/how-to/zugferd-invoice/  
**Video walkthrough:** https://www.youtube.com/watch?v=W_yi_3orJZA  
**Short version:** https://www.youtube.com/shorts/GlTK8eSaSHw

## Run it

```bash
dotnet run
```

The program writes `invoice-2026-001.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- ExistingPdf` | Turn an existing PDF invoice into a hybrid invoice ([ExistingPdf.cs](ExistingPdf.cs)) |
| `dotnet run --project variations -- AccessibleInvoice` | An accessible PDF/A-3A invoice ([AccessibleInvoice.cs](AccessibleInvoice.cs)) |
| `dotnet run --project variations -- Zugferd20Metadata` | The deprecated ZUGFeRD 2.0 metadata ([Zugferd20Metadata.cs](Zugferd20Metadata.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Electronic Invoices (ZUGFeRD / Factur-X)](https://selectpdf.com/pdf-library/html/ElectronicInvoices.htm)
- [PdfDocument.AddZugferdInvoice](https://selectpdf.com/pdf-library/html/Overload_SelectPdf_Universal_PdfDocument_AddZugferdInvoice.htm)
- [ZugferdProfile enumeration](https://selectpdf.com/pdf-library/html/T_SelectPdf_Universal_ZugferdProfile.htm)
