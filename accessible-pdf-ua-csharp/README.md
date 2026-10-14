# Accessible PDF/UA from HTML in C# (tagged PDF)

Create accessible, tagged PDF/UA-1 and PDF/UA-2 documents from HTML in C#, with PDF/A-4 or PDF/A-3A for archiving, all validated with veraPDF.

**Step-by-step guide:** https://selectpdf.com/how-to/accessible-pdf-ua-csharp/

## Run it

```bash
dotnet run
```

The program writes `report-ua1.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- PdfUA2` | PDF/UA-2 and PDF/A-4 in one file ([PdfUA2.cs](PdfUA2.cs)) |
| `dotnet run --project variations -- ArchivedInvoice` | An archived, accessible invoice (PDF/A-3A and PDF/UA-1) ([ArchivedInvoice.cs](ArchivedInvoice.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Accessible PDF (tagged PDF) and PDF/A](https://selectpdf.com/pdf-library/html/AccessiblePdf.htm)
- [HtmlToPdfOptions.AccessibilityStandard](https://selectpdf.com/pdf-library/html/P_SelectPdf_Universal_HtmlToPdfOptions_AccessibilityStandard.htm)
- [HtmlToPdfOptions.PdfStandard](https://selectpdf.com/pdf-library/html/P_SelectPdf_Universal_HtmlToPdfOptions_PdfStandard.htm)
