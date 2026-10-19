# Redact PDF text with a regular expression in C#

Remove sensitive text such as card numbers from a PDF in C# with SelectPdf.Universal. The content is deleted from the file, not just covered over.

**Step-by-step guide:** https://selectpdf.com/how-to/redact-pdf-regex/  
**Video walkthrough:** https://www.youtube.com/watch?v=vE-0wYoUVj4  
**Short version:** https://www.youtube.com/shorts/qgU6YCSKHnk

## Run it

```bash
dotnet run
```

The program writes `statement-redacted.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- RedactKnownText` | Redact a known name or phrase ([RedactKnownText.cs](RedactKnownText.cs)) |
| `dotnet run --project variations -- RedactArea` | Redact a fixed area and work in memory ([RedactArea.cs](RedactArea.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [PDF redaction](https://selectpdf.com/pdf-library/html/PdfRedaction.htm)
- [PdfRedactionManager class](https://selectpdf.com/pdf-library/html/T_SelectPdf_Universal_PdfRedactionManager.htm)
- [Search text in a PDF](https://selectpdf.com/pdf-library/html/SearchPdfText.htm)
