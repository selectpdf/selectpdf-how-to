using SelectPdf.Universal;

// 1. Make a three-page report to read back.
HtmlToPdf converter = new HtmlToPdf();
PdfDocument report = converter.ConvertHtmlString("""
    <h1>Quarterly report</h1><p>Revenue grew 12% to 4.2 million.</p>
    <h2 style="page-break-before: always">Costs</h2><p>Operating costs stayed at 3.1 million.</p>
    <h2 style="page-break-before: always">Outlook</h2><p>Growth is expected to continue.</p>
    """);
report.Save("report.pdf");
report.Close();

// 2. Load the PDF and get all of its text as a string.
PdfToText pdfToText = new PdfToText();
pdfToText.Load("report.pdf");
string text = pdfToText.GetText();
Console.WriteLine(text);

// 3. Write the same text to a UTF-8 file and release the PDF.
pdfToText.SaveText("report.txt");
pdfToText.Close();
