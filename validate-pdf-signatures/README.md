# Validate PDF digital signatures in C#

Validate PDF digital signatures in C# with SelectPdf.Universal: check they are intact and trusted, and detect tampering, later changes and revoked certificates.

**Step-by-step guide:** https://selectpdf.com/how-to/validate-pdf-signatures/  
**Video walkthrough:** https://www.youtube.com/watch?v=xri-j_PQ0Ko  
**Short version:** https://www.youtube.com/shorts/AMpPrVC_5PQ

## Run it

```bash
dotnet run
```

The program writes `contract-signed.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- TamperedCopy` | Detect a file that was changed after signing ([TamperedCopy.cs](TamperedCopy.cs)) |
| `dotnet run --project variations -- Countersigned` | Two signatures, one after the other ([Countersigned.cs](Countersigned.cs)) |
| `dotnet run --project variations -- RevocationCheck` | Check whether the certificate was revoked ([RevocationCheck.cs](RevocationCheck.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Digital signatures: validating signatures](https://selectpdf.com/pdf-library/html/DigitalSignatures.htm)
- [PdfSignatureValidationResult](https://selectpdf.com/pdf-library/html/T_SelectPdf_Universal_PdfSignatureValidationResult.htm)
- [PdfSignatureStatus](https://selectpdf.com/pdf-library/html/T_SelectPdf_Universal_PdfSignatureStatus.htm)
