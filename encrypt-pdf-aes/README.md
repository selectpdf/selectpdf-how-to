# Password-protect a PDF with AES-256 in C#

Encrypt a PDF with AES-256 in C#: set an open password, block printing and copying with an owner password, or protect an existing file with SelectPdf.Universal.

**Step-by-step guide:** https://selectpdf.com/how-to/encrypt-pdf-aes/

## Run it

```bash
dotnet run
```

The program writes `payslip-protected.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- RestrictPermissions` | Block printing and copying with an owner password ([RestrictPermissions.cs](RestrictPermissions.cs)) |
| `dotnet run --project variations -- EncryptExistingFile` | Encrypt an existing PDF file ([EncryptExistingFile.cs](EncryptExistingFile.cs)) |
| `dotnet run --project variations -- EncryptDuringConversion` | Encrypt during HTML to PDF conversion ([EncryptDuringConversion.cs](EncryptDuringConversion.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [PDF security](https://selectpdf.com/pdf-library/html/PdfSecurity.htm)
- [Advanced security settings](https://selectpdf.com/pdf-library/html/AdvancedSecurity.htm)
- [Encrypting regulated data](https://selectpdf.com/pdf-library/html/EncryptingRegulatedData.htm)
