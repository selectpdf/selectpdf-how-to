# Flatten a PDF form in C#

Flatten a PDF form in C#: create a fillable form from HTML, fill it, and turn the values into page content, for all fields or some, or for an existing PDF file.

**Step-by-step guide:** https://selectpdf.com/how-to/flatten-pdf-form/  
**Video walkthrough:** https://www.youtube.com/watch?v=lWNoGnV_gU4  
**Short version:** https://www.youtube.com/shorts/wl8G4hmBNgo

## Run it

```bash
dotnet run
```

The program writes `application-flattened.pdf` to the current folder. Requires the .NET 10 SDK; the project picks SelectPdf's engine package for the machine that builds it (Windows x64/x86, Linux x64/ARM64, macOS on Apple Silicon).

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- FlattenSomeFields` | Flatten only some fields ([FlattenSomeFields.cs](FlattenSomeFields.cs)) |
| `dotnet run --project variations -- FlattenAndProtect` | Flatten the form, then protect the file ([FlattenAndProtect.cs](FlattenAndProtect.cs)) |
| `dotnet run --project variations -- FlattenExistingFile` | Fill and flatten an existing PDF file ([FlattenExistingFile.cs](FlattenExistingFile.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Form filling](https://selectpdf.com/pdf-library/html/FormFilling.htm)
- [HTML forms to PDF form fields](https://selectpdf.com/pdf-library/html/HtmlFormsToPdfFields.htm)
- [PdfFormManager.Flatten](https://selectpdf.com/pdf-library/html/P_SelectPdf_Universal_PdfFormManager_Flatten.htm)
- [PdfFormField.Flatten](https://selectpdf.com/pdf-library/html/P_SelectPdf_Universal_PdfFormField_Flatten.htm)
- [PdfFormManager.CompactSave](https://selectpdf.com/pdf-library/html/P_SelectPdf_Universal_PdfFormManager_CompactSave.htm)
