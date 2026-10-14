using SelectPdf.Universal;

static class PdfA1b
{
    public static void Run()
    {
        HtmlToPdf converter = new HtmlToPdf();

        // PdfStandard.PdfA is PDF/A-1b, for archives that accept only the first part
        converter.Options.PdfStandard = PdfStandard.PdfA;
        converter.Options.PdfDocumentInformation.Title = "Statement 2026-09";

        PdfDocument doc = converter.ConvertHtmlString(
            "<h1>Statement 2026-09</h1><p>Closing balance: 4,250.00</p>");
        doc.Save("statement-pdfa1b.pdf");
        doc.Close();
    }
}
