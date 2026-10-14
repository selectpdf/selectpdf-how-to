# Fill PDF form fields in C#

Fill PDF form fields in C#: create a fillable form from HTML, set text boxes, check boxes, combo boxes and radio buttons by name, then save the filled PDF.

**Step-by-step guide:** https://selectpdf.com/how-to/fill-pdf-form/

## Run it

```bash
dotnet run
```

The program writes `registration-filled.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- ListFormFields` | List the fields of a form with their types and values ([ListFormFields.cs](ListFormFields.cs)) |
| `dotnet run --project variations -- FillAndLock` | Fill a form in memory and make it read-only ([FillAndLock.cs](FillAndLock.cs)) |
| `dotnet run --project variations -- FillFromJson` | Fill a form from JSON values ([FillFromJson.cs](FillFromJson.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Form filling](https://selectpdf.com/pdf-library/html/FormFilling.htm)
- [HTML forms to PDF form fields](https://selectpdf.com/pdf-library/html/HtmlFormsToPdfFields.htm)
- [HtmlToPdfOptions.CreateFormFields](https://selectpdf.com/pdf-library/html/P_SelectPdf_Universal_HtmlToPdfOptions_CreateFormFields.htm)
- [PdfFormManager class](https://selectpdf.com/pdf-library/html/T_SelectPdf_Universal_PdfFormManager.htm)
