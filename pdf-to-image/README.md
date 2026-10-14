# Convert PDF pages to PNG images in C#

Render every page of a PDF to a PNG image in C# with SelectPdf.Universal at the resolution you choose, plus a first-page thumbnail, JPG files and grayscale.

**Step-by-step guide:** https://selectpdf.com/how-to/pdf-to-image/

## Run it

```bash
dotnet run
```

The program writes `report.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- FirstPageThumbnail` | A thumbnail of the first page ([FirstPageThumbnail.cs](FirstPageThumbnail.cs)) |
| `dotnet run --project variations -- JpegFiles` | Write JPG files with Save ([JpegFiles.cs](JpegFiles.cs)) |
| `dotnet run --project variations -- GrayscaleInMemory` | Grayscale images, from bytes to a stream ([GrayscaleInMemory.cs](GrayscaleInMemory.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Convert PDF pages to images](https://selectpdf.com/pdf-library/html/PdfToImageConverter.htm)
- [PdfRasterizer class](https://selectpdf.com/pdf-library/html/T_SelectPdf_Universal_PdfRasterizer.htm)
- [PdfTool.Load overloads](https://selectpdf.com/pdf-library/html/Overload_SelectPdf_Universal_PdfTool_Load.htm)
