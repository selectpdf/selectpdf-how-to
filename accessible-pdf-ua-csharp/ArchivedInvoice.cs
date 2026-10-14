using SelectPdf.Universal;

static class ArchivedInvoice
{
    public static void Run()
    {
        string html = """
            <html lang="en">
            <head><title>Invoice 2026-0042</title></head>
            <body>
              <h1>Invoice 2026-0042</h1>
              <p>Billed to Contoso Ltd.</p>
            </body>
            </html>
            """;

        HtmlToPdf converter = new HtmlToPdf();

        // PDF/A-3A (archival, level A = accessible) together with PDF/UA-1
        converter.Options.PdfStandard = PdfStandard.PdfA3A;
        converter.Options.AccessibilityStandard = PdfUAStandard.UA1;
        converter.Options.Title = "Invoice 2026-0042";
        converter.Options.Language = "en-US";

        PdfDocument doc = converter.ConvertHtmlString(html);
        doc.Save("invoice-pdfa3a-ua1.pdf");
        doc.Close();
    }
}
