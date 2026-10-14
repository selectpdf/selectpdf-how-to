using SelectPdf.Universal;

// HTML written for accessibility: a language, headings in order, alt text, a real table
string html = """
    <html lang="en">
    <head><title>Quarterly report</title></head>
    <body>
      <h1>Quarterly report</h1>
      <p>Revenue grew in every region this quarter.</p>
      <img src="https://selectpdf.com/img/selectpdf-logo-h128.png" alt="SelectPdf logo" height="40">
      <h2>Revenue by region</h2>
      <table>
        <thead><tr><th scope="col">Region</th><th scope="col">Revenue</th></tr></thead>
        <tbody>
          <tr><td>Europe</td><td>1,200,000</td></tr>
          <tr><td>Americas</td><td>900,000</td></tr>
        </tbody>
      </table>
    </body>
    </html>
    """;

HtmlToPdf converter = new HtmlToPdf();

// declare PDF/UA-1: tags the document and writes the PDF/UA identifier
converter.Options.AccessibilityStandard = PdfUAStandard.UA1;

// PDF/UA requires a document title and a language
converter.Options.Title = "Quarterly report";
converter.Options.Language = "en-US";

PdfDocument doc = converter.ConvertHtmlString(html);
doc.Save("report-ua1.pdf");
doc.Close();
