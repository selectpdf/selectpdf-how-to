using SelectPdf.Universal;

static class PdfUA2
{
    public static void Run()
    {
        string html = """
            <html lang="en">
            <head><title>Annual report</title></head>
            <body>
              <h1>Annual report</h1>
              <p>Accessible and archived: PDF/UA-2 and PDF/A-4 in one file.</p>
            </body>
            </html>
            """;

        HtmlToPdf converter = new HtmlToPdf();

        // PDF/UA-2 is defined on PDF 2.0, so the only archival level it combines with is PDF/A-4
        converter.Options.AccessibilityStandard = PdfUAStandard.UA2;
        converter.Options.PdfStandard = PdfStandard.PdfA4;
        converter.Options.Title = "Annual report";
        converter.Options.Language = "en-US";

        PdfDocument doc = converter.ConvertHtmlString(html);
        doc.Save("report-ua2-pdfa4.pdf");
        doc.Close();
    }
}
