# Convert PDF to an editable Word document in C#

Convert a PDF to an editable Word document in C# with SelectPdf: headings, lists, tables, pictures and links kept. PDF to Excel and PowerPoint work alike.

**Step-by-step guide:** https://selectpdf.com/how-to/pdf-to-word-csharp/  
**Video walkthrough:** https://www.youtube.com/watch?v=sH4tN6DTTMc  
**Short version:** https://www.youtube.com/shorts/P7eXBNmS5u8

## Run it

```bash
dotnet run
```

The program writes `report.docx` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- ExactLayout` | Exact layout: every page as it is ([ExactLayout.cs](ExactLayout.cs)) |
| `dotnet run --project variations -- MarkdownOutput` | PDF to Markdown ([MarkdownOutput.cs](MarkdownOutput.cs)) |
| `dotnet run --project variations -- PdfToExcelTables` | PDF to Excel: the tables as cells ([PdfToExcelTables.cs](PdfToExcelTables.cs)) |
| `dotnet run --project variations -- PdfToPowerPointSlides` | PDF to PowerPoint: a slide per page ([PdfToPowerPointSlides.cs](PdfToPowerPointSlides.cs)) |
| `dotnet run --project variations -- PageRangeFromStream` | Convert some of the pages, from a stream ([PageRangeFromStream.cs](PageRangeFromStream.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Convert PDF to Word, Excel and PowerPoint](https://selectpdf.com/pdf-library/html/PdfToOffice.htm)
- [PdfToWord class](https://selectpdf.com/pdf-library/html/T_SelectPdf_Universal_PdfToWord.htm)
- [PDF to Word converter options](https://selectpdf.com/pdf-library/html/T_SelectPdf_Universal_PdfToWordOptions.htm)
