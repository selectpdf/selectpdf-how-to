# Convert Word documents to PDF/A for archiving in C#

Convert Word DOCX files to archival PDF/A in C#: PDF/A-2b with title metadata, PDF/A-4, accessible PDF/A-3a with PDF/UA-1, and merging into PDF/A.

**Step-by-step guide:** https://selectpdf.com/how-to/word-to-pdf-a/  
**Video walkthrough:** https://www.youtube.com/watch?v=gE-3q8-ykdo  
**Short version:** https://www.youtube.com/shorts/9RzqZi5wAr0

## Run it

```bash
dotnet run
```

The program writes `board-minutes-pdfa2b.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- PdfA4` | PDF/A-4, the level defined on PDF 2.0 ([PdfA4.cs](PdfA4.cs)) |
| `dotnet run --project variations -- AccessiblePdfA3a` | Archival and accessible: PDF/A-3a with PDF/UA-1 ([AccessiblePdfA3a.cs](AccessiblePdfA3a.cs)) |
| `dotnet run --project variations -- MergeDocxIntoPdfA` | Merge several Word documents into one PDF/A file ([MergeDocxIntoPdfA.cs](MergeDocxIntoPdfA.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Convert Word documents to PDF](https://selectpdf.com/pdf-library/html/WordToPdfConverter.htm)
- [Word to PDF converter options](https://selectpdf.com/pdf-library/html/WordToPdfOptions.htm)
- [Accessible PDF (tagged PDF) and PDF/A](https://selectpdf.com/pdf-library/html/AccessiblePdf.htm)
