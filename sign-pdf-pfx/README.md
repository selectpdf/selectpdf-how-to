# Digitally sign a PDF with a PFX certificate in C#

Digitally sign a PDF in C# with a .pfx certificate and SelectPdf.Universal: a visible signature with reason and location, a seal image, and a second signer.

**Step-by-step guide:** https://selectpdf.com/how-to/sign-pdf-pfx/  
**Video walkthrough:** https://www.youtube.com/watch?v=xUjMgGqCwPw  
**Short version:** https://www.youtube.com/shorts/SJsz0_kiH8c

## Run it

```bash
dotnet run
```

The program writes `contract-signed.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- SignNewDocument` | Sign the converter output before it is saved ([SignNewDocument.cs](SignNewDocument.cs)) |
| `dotnet run --project variations -- CustomAppearance` | A seal or logo behind the signature text ([CustomAppearance.cs](CustomAppearance.cs)) |
| `dotnet run --project variations -- TwoSignatures` | A second signer countersigns ([TwoSignatures.cs](TwoSignatures.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Digital signatures](https://selectpdf.com/pdf-library/html/DigitalSignatures.htm)
- [PdfSecurityManager](https://selectpdf.com/pdf-library/html/T_SelectPdf_Universal_PdfSecurityManager.htm)
- [PdfDigitalSignatureElement](https://selectpdf.com/pdf-library/html/T_SelectPdf_Universal_PdfDigitalSignatureElement.htm)
