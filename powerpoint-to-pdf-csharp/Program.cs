using SelectPdf.Universal;

PowerPointToPdf converter = new PowerPointToPdf();

// one page per slide, each page the size of the slides (both are the defaults)
converter.Options.Publish = PowerPointPublish.Slides;
converter.Options.PageSetup = PowerPointPageSetup.Document;

// document properties of the PDF
converter.Options.PdfDocumentInformation.Title = "Quarterly review";
converter.Options.PdfDocumentInformation.Author = "Sales team";

PdfDocument doc = converter.ConvertFile("presentation.pptx");
Console.WriteLine($"{converter.ConversionResult.PdfPageCount} pages");

doc.Save("presentation.pdf");
doc.Close();
