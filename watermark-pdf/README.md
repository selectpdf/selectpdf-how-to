# Add a watermark to every page of a PDF in C#

Stamp a rotated, semi-transparent CONFIDENTIAL watermark on every page of an existing PDF in C# with SelectPdf.Universal, plus logo and DRAFT variations.

**Step-by-step guide:** https://selectpdf.com/how-to/watermark-pdf/  
**Video walkthrough:** https://www.youtube.com/watch?v=zJVXbp0TraI  
**Short version:** https://www.youtube.com/shorts/jblNxOcXQBE

## Run it

```bash
dotnet run
```

The program writes `report-watermarked.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- ImageWatermark` | Watermark with a logo image ([ImageWatermark.cs](ImageWatermark.cs)) |
| `dotnet run --project variations -- DraftBehindContent` | Stamp the converter output, behind the text ([DraftBehindContent.cs](DraftBehindContent.cs)) |
| `dotnet run --project variations -- SkipFirstPage` | A corner stamp on every page except the first ([SkipFirstPage.cs](SkipFirstPage.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [PDF stamps and watermarks](https://selectpdf.com/pdf-library/html/PdfStampsAndWatermarks.htm)
- [PDF templates](https://selectpdf.com/pdf-library/html/PdfTemplates.htm)
- [Modify existing PDF documents](https://selectpdf.com/pdf-library/html/ModifyExistingPdf.htm)
