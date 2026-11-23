# Convert PowerPoint presentations to PDF in C#

Convert PowerPoint presentations to PDF in C#: one page per slide, handouts with two slides on each A4 page, speaker notes pages and accessible PDF/A-3a.

**Step-by-step guide:** https://selectpdf.com/how-to/powerpoint-to-pdf-csharp/  
**Video walkthrough:** https://www.youtube.com/watch?v=EUDmQMXpqoA  
**Short version:** https://www.youtube.com/shorts/unIb_HmguaA

## Run it

```bash
dotnet run
```

The program writes `presentation.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- HandoutsOnA4` | Handouts: two slides on each A4 page, with page numbers ([HandoutsOnA4.cs](HandoutsOnA4.cs)) |
| `dotnet run --project variations -- NotesPages` | Notes pages: each slide with its speaker notes ([NotesPages.cs](NotesPages.cs)) |
| `dotnet run --project variations -- AccessiblePdfUa` | Accessible and archival: PDF/A-3a with PDF/UA-1 ([AccessiblePdfUa.cs](AccessiblePdfUa.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Convert PowerPoint presentations to PDF](https://selectpdf.com/pdf-library/html/PowerPointToPdfConverter.htm)
- [PowerPoint to PDF converter options](https://selectpdf.com/pdf-library/html/PowerPointToPdfOptions.htm)
- [Accessible PDF (tagged PDF) and PDF/A](https://selectpdf.com/pdf-library/html/AccessiblePdf.htm)
