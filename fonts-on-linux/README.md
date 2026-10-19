# Fonts on Linux: the same PDF on every server, in every language (C#)

Make HTML to PDF in C# look the same on Windows and Linux with SelectPdf.Universal: built-in Liberation fonts, Noto fonts for every script, your own fonts.

**Step-by-step guide:** https://selectpdf.com/how-to/fonts-on-linux/  
**Video walkthrough:** https://www.youtube.com/watch?v=ipV-9sPhxak  
**Short version:** https://www.youtube.com/shorts/AcHScBbVDCg

## Run it

```bash
dotnet run
```

The program writes `languages.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- CorporateFont` | Your company font, shipped with the application ([CorporateFont.cs](CorporateFont.cs)) |
| `dotnet run --project variations -- WebFontFromUrl` | A web font from a font service ([WebFontFromUrl.cs](WebFontFromUrl.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Fonts and languages](https://selectpdf.com/pdf-library/html/Fonts-And-Languages.htm)
- [Deployment with Docker](https://selectpdf.com/pdf-library/html/Deployment-Docker.htm)
- [Cloud deployments](https://selectpdf.com/pdf-library/html/Cloud-Deployments.htm)
