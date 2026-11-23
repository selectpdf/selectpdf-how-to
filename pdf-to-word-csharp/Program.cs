using SelectPdf.Universal;

PdfToWord converter = new PdfToWord();

// Flowing (the default): paragraphs that reflow as you edit, as in any Word document
converter.Options.Layout = PdfToWordLayout.Flowing;
converter.Options.Format = PdfToWordFormat.Docx;

// convert the PDF and write the Word document
byte[] docx = converter.ConvertFile("report.pdf");
File.WriteAllBytes("report.docx", docx);

// what became of each font: embedded, substituted or named only
foreach (PdfToWordFont font in converter.ConversionResult.Fonts)
    Console.WriteLine(font);
