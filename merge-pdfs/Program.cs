using SelectPdf.Universal;

// two source PDFs
HtmlToPdf converter = new HtmlToPdf();
PdfDocument a = converter.ConvertHtmlString("<h1>Cover letter</h1>");
a.Save("a.pdf");
a.Close();
PdfDocument b = converter.ConvertHtmlString("<h1>Contract</h1>");
b.Save("b.pdf");
b.Close();

// merge: append both files into a new document
PdfDocument merged = new PdfDocument();
merged.Append("a.pdf");
merged.Append("b.pdf");
merged.Save("merged.pdf");
merged.Close();
