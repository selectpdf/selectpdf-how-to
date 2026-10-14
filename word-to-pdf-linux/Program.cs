using SelectPdf.Universal;

WordToPdf converter = new WordToPdf();

// Document (the default): every page keeps the size and orientation it has in Word
converter.Options.PageSetup = WordPageSetup.Document;

// the PDF outline is built from the document's headings
converter.Options.Bookmarks = WordBookmarks.Headings;

// the format is taken from the file extension
PdfDocument doc = converter.ConvertFile("report.docx");
Console.WriteLine($"Pages: {converter.ConversionResult.PdfPageCount}, bookmarks: {doc.Bookmarks.Count}");

doc.Save("report.pdf");
doc.Close();
