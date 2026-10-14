# Merge PDF files in C#: files, streams and folders

Merge PDF files in C# with SelectPdf.Universal: combine files, in-memory streams, converted HTML or a whole folder into one PDF, on Windows, Linux and macOS.

**Step-by-step guide:** https://selectpdf.com/how-to/merge-pdfs/

## Run it

```bash
dotnet run
```

The program writes `merged.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- MergeInMemory` | Merge PDFs from byte arrays or streams ([MergeInMemory.cs](MergeInMemory.cs)) |
| `dotnet run --project variations -- MergeConvertedPages` | Merge converted HTML without temporary files ([MergeConvertedPages.cs](MergeConvertedPages.cs)) |
| `dotnet run --project variations -- MergeFolder` | Merge every PDF in a folder ([MergeFolder.cs](MergeFolder.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Merge PDF documents](https://selectpdf.com/pdf-library/html/PdfMerge.htm)
- [PdfDocument.Append](https://selectpdf.com/pdf-library/html/M_SelectPdf_Universal_PdfDocument_Append.htm)
- [Modify existing PDFs](https://selectpdf.com/pdf-library/html/ModifyExistingPdf.htm)
