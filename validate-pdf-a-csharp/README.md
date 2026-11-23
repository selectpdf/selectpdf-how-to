# Validate PDF/A compliance in C# and fix what fails

Validate a PDF against PDF/A-2b in C# with PdfValidator, read each failed rule from the ValidationReport, then fix it with PdfPreflight.Fix and check again.

**Step-by-step guide:** https://selectpdf.com/how-to/validate-pdf-a-csharp/  
**Video walkthrough:** https://www.youtube.com/watch?v=sfAd1QsoFZw  
**Short version:** https://www.youtube.com/shorts/jHHLx-QuRSA

## Run it

```bash
dotnet run
```

The program writes `annual-report-pdfa2b.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- ClaimedStandard` | Check a file at the level it declares ([ClaimedStandard.cs](ClaimedStandard.cs)) |
| `dotnet run --project variations -- AccessiblePdfUA1` | Fix for PDF/UA-1, then add what needs a person ([AccessiblePdfUA1.cs](AccessiblePdfUA1.cs)) |
| `dotnet run --project variations -- ValidationLimits` | Limit the failures listed and the time taken ([ValidationLimits.cs](ValidationLimits.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Validate PDF documents against PDF/A, PDF/UA and PDF/X](https://selectpdf.com/pdf-library/html/PdfValidation.htm)
- [Fix PDF documents for PDF/A, PDF/UA and PDF/X (preflight)](https://selectpdf.com/pdf-library/html/PdfPreflight.htm)
- [Alternative text for images in existing PDF documents](https://selectpdf.com/pdf-library/html/PdfAlternateText.htm)
- [ValidationReport](https://selectpdf.com/pdf-library/html/T_SelectPdf_Universal_ValidationReport.htm)
