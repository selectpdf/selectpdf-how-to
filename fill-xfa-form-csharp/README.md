# Fill a dynamic XFA form in C#

Fill a dynamic XFA form in C#: set field values that run the form's own calculations and validation, then save it as an XFA form or as flattened pages.

**Step-by-step guide:** https://selectpdf.com/how-to/fill-xfa-form-csharp/  
**Video walkthrough:** https://www.youtube.com/watch?v=3JHCch8Y-5o  
**Short version:** https://www.youtube.com/shorts/lxNDLcSKqcs

## Run it

```bash
dotnet run
```

The program writes `xfa-form-flattened.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- ListXfaFields` | List the fields of an XFA form with what they show ([ListXfaFields.cs](ListXfaFields.cs)) |
| `dotnet run --project variations -- CheckWithFormScripts` | Read what the form's scripts report and press its buttons ([CheckWithFormScripts.cs](CheckWithFormScripts.cs)) |
| `dotnet run --project variations -- SignXfaForm` | Sign the form's own signature field ([SignXfaForm.cs](SignXfaForm.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Form filling: XFA forms](https://selectpdf.com/pdf-library/html/FormFilling.htm#Xfa)
- [PdfFormManager class](https://selectpdf.com/pdf-library/html/T_SelectPdf_Universal_PdfFormManager.htm)
- [PdfFormXfaMode enumeration](https://selectpdf.com/pdf-library/html/T_SelectPdf_Universal_PdfFormXfaMode.htm)
- [Release notes, version 26.6](https://selectpdf.com/pdf-library/html/Release-Notes-v26-6.htm)
