# Convert HTML to PDF/A for archiving in C#

Convert HTML to archival PDF/A in C#: PDF/A-2b with metadata, PDF/A-1b, PDF/A-3b with an embedded source file, and merging into PDF/A, validated by veraPDF.

**Step-by-step guide:** https://selectpdf.com/how-to/html-to-pdf-a/  
**Video walkthrough:** https://www.youtube.com/watch?v=xYj_IyVR5TE  
**Short version:** https://www.youtube.com/shorts/RZ7bXK5VJ5A

## Run it

```bash
dotnet run
```

The program writes `contract-pdfa2b.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- PdfA1b` | PDF/A-1b for archives that require the first part ([PdfA1b.cs](PdfA1b.cs)) |
| `dotnet run --project variations -- PdfA3bWithSource` | PDF/A-3b with the source data embedded ([PdfA3bWithSource.cs](PdfA3bWithSource.cs)) |
| `dotnet run --project variations -- MergeIntoPdfA` | Merge converted pages into a PDF/A document ([MergeIntoPdfA.cs](MergeIntoPdfA.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Accessible PDF (tagged PDF) and PDF/A](https://selectpdf.com/pdf-library/html/AccessiblePdf.htm)
- [PdfStandard enumeration](https://selectpdf.com/pdf-library/html/T_SelectPdf_Universal_PdfStandard.htm)
- [PdfDocument.AddAssociatedFile](https://selectpdf.com/pdf-library/html/M_SelectPdf_Universal_PdfDocument_AddAssociatedFile.htm)
