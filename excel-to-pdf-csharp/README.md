# Convert Excel workbooks to PDF in C#

Convert Excel workbooks to PDF in C# with SelectPdf: xlsx, xls and csv files, all columns on one page, selected sheets on A4, and accessible PDF/A-3a output.

**Step-by-step guide:** https://selectpdf.com/how-to/excel-to-pdf-csharp/  
**Video walkthrough:** https://www.youtube.com/watch?v=z6bY86BqRo0  
**Short version:** https://www.youtube.com/shorts/6fUQjq5f8-E

## Run it

```bash
dotnet run
```

The program writes `sales.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- OneSheetOnA4` | One sheet on an A4 page, with page numbers ([OneSheetOnA4.cs](OneSheetOnA4.cs)) |
| `dotnet run --project variations -- AccessiblePdfA3a` | Archival and accessible: PDF/A-3a with PDF/UA-1 ([AccessiblePdfA3a.cs](AccessiblePdfA3a.cs)) |
| `dotnet run --project variations -- ExcelInPageRegion` | A sheet in a region of a PDF page ([ExcelInPageRegion.cs](ExcelInPageRegion.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Convert Excel workbooks to PDF](https://selectpdf.com/pdf-library/html/ExcelToPdfConverter.htm)
- [Excel to PDF converter options](https://selectpdf.com/pdf-library/html/ExcelToPdfOptions.htm)
- [Draw a workbook on a page: PdfExcelElement](https://selectpdf.com/pdf-library/html/PdfExcelElement.htm)
- [Accessible PDF (tagged PDF) and PDF/A](https://selectpdf.com/pdf-library/html/AccessiblePdf.htm)
