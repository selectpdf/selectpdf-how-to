# Take a full-page screenshot of a website in C#

Capture a whole web page as one PNG in C# with SelectPdf.Universal HtmlToImage: auto height, a first-screen crop, a phone-width capture and script delays.

**Step-by-step guide:** https://selectpdf.com/how-to/full-page-screenshot/  
**Video walkthrough:** https://www.youtube.com/watch?v=YIkAZ24vgVE  
**Short version:** https://www.youtube.com/shorts/7yMVGnzHLuM

## Run it

```bash
dotnet run
```

The program writes `full-page.png` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- ViewportOnly` | Only the first screen, 1280 by 800 ([ViewportOnly.cs](ViewportOnly.cs)) |
| `dotnet run --project variations -- MobileWidth` | A full-page capture at phone width ([MobileWidth.cs](MobileWidth.cs)) |
| `dotnet run --project variations -- WaitForScripts` | Wait for content that scripts add ([WaitForScripts.cs](WaitForScripts.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Convert URL to image](https://selectpdf.com/pdf-library/html/ConvertUrlToImage.htm)
- [HtmlToImage class](https://selectpdf.com/pdf-library/html/T_SelectPdf_Universal_HtmlToImage.htm)
- [HtmlToImage.WebPageHeight](https://selectpdf.com/pdf-library/html/P_SelectPdf_Universal_HtmlToImage_WebPageHeight.htm)
