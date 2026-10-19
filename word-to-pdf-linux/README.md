# Convert DOCX to PDF on Linux in C#

Convert Word DOCX files to PDF on Linux in C# with SelectPdf.Universal, and no Microsoft Office installed. Missing fonts come from the bundled Liberation fonts.

**Step-by-step guide:** https://selectpdf.com/how-to/word-to-pdf-linux/  
**Video walkthrough:** https://www.youtube.com/watch?v=MqtrGrtKcEA  
**Short version:** https://www.youtube.com/shorts/J2oBXiT0WYU

## Run it

```bash
dotnet run
```

The program writes `report.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- ReflowA4Landscape` | Reflow onto A4 landscape with page numbers ([ReflowA4Landscape.cs](ReflowA4Landscape.cs)) |
| `dotnet run --project variations -- ConvertUploadedBytes` | Convert a DOCX held in memory ([ConvertUploadedBytes.cs](ConvertUploadedBytes.cs)) |
| `dotnet run --project variations -- AddCoverPage` | Put a cover page in front of the converted document ([AddCoverPage.cs](AddCoverPage.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Convert Word documents to PDF](https://selectpdf.com/pdf-library/html/WordToPdfConverter.htm)
- [Word to PDF converter options](https://selectpdf.com/pdf-library/html/WordToPdfOptions.htm)
- [Fonts and languages](https://selectpdf.com/pdf-library/html/Fonts-And-Languages.htm)
