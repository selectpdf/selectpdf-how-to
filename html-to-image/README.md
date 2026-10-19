# Convert HTML to PNG or JPG in C#

Convert a URL or an HTML string to a PNG or JPG image in C# with HtmlToImage: set the browser size, resolve relative images, capture one element, go async.

**Step-by-step guide:** https://selectpdf.com/how-to/html-to-image/  
**Video walkthrough:** https://www.youtube.com/watch?v=Ob0ohXmFdY8  
**Short version:** https://www.youtube.com/shorts/GZUcmacjuX4

## Run it

```bash
dotnet run
```

The program writes `webpage.png` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- JpgImage` | Save the image as JPG ([JpgImage.cs](JpgImage.cs)) |
| `dotnet run --project variations -- OneElement` | Capture one element of the page ([OneElement.cs](OneElement.cs)) |
| `dotnet run --project variations -- AsyncToStream` | Convert asynchronously and write to a stream ([AsyncToStream.cs](AsyncToStream.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Convert Url to Image](https://selectpdf.com/pdf-library/html/ConvertUrlToImage.htm)
- [Convert Html Code to Image](https://selectpdf.com/pdf-library/html/ConvertHtmlCodeToImage.htm)
- [HtmlToImage class](https://selectpdf.com/pdf-library/html/T_SelectPdf_Universal_HtmlToImage.htm)
