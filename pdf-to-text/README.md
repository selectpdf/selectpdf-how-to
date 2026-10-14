# Extract text from a PDF in C#

Extract the text of a PDF in C# with SelectPdf.Universal: get it as a string or save it to a UTF-8 file, read a page range, keep columns or reading order.

**Step-by-step guide:** https://selectpdf.com/how-to/pdf-to-text/

## Run it

```bash
dotnet run
```

The program writes `report.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- PageRange` | Extract one page or a range of pages ([PageRange.cs](PageRange.cs)) |
| `dotnet run --project variations -- ReadingOrder` | Text in reading order instead of the page layout ([ReadingOrder.cs](ReadingOrder.cs)) |
| `dotnet run --project variations -- SearchText` | Find text and highlight it ([SearchText.cs](SearchText.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Extract text from PDF](https://selectpdf.com/pdf-library/html/PdfToTextConverter.htm)
- [Search for text in PDF](https://selectpdf.com/pdf-library/html/SearchPdfText.htm)
- [PdfToText class](https://selectpdf.com/pdf-library/html/T_SelectPdf_Universal_PdfToText.htm)
