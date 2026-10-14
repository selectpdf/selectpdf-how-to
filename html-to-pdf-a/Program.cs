using SelectPdf.Universal;

string html = """
    <html lang="en">
    <head><title>Contract 2026-117</title></head>
    <body>
      <h1>Service contract 2026-117</h1>
      <p>Signed on 13 October 2026 between Contoso Ltd. and Fabrikam Inc.</p>
      <p>This copy is kept for the full retention period.</p>
    </body>
    </html>
    """;

HtmlToPdf converter = new HtmlToPdf();

// PDF/A-2b: archival output, with every font embedded
converter.Options.PdfStandard = PdfStandard.PdfA2B;

// document metadata, written into the archived file
converter.Options.PdfDocumentInformation.Title = "Service contract 2026-117";
converter.Options.PdfDocumentInformation.Author = "Contracts department";
converter.Options.PdfDocumentInformation.Subject = "Signed service contract";

PdfDocument doc = converter.ConvertHtmlString(html);
doc.Save("contract-pdfa2b.pdf");
doc.Close();
