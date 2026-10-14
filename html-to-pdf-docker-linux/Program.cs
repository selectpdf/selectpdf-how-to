using SelectPdf.Universal;

string html = """
    <html>
      <body style="font-family: sans-serif">
        <h1>Invoice #1042</h1>
        <p>Rendered on Linux by SelectPdf.Universal.</p>
      </body>
    </html>
    """;

HtmlToPdf converter = new HtmlToPdf();
PdfDocument doc = converter.ConvertHtmlString(html);
doc.Save("invoice.pdf");
doc.Close();
