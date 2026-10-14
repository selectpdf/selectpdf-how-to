using SelectPdf.Universal;

static class PrintStylesheet
{
    public static void Run()
    {
        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.PdfPageSize = PdfPageSize.A4;

        // use the page's @media print rules, as the browser's Print command does
        converter.Options.CssMediaType = HtmlToPdfCssMediaType.Print;

        PdfDocument doc = converter.ConvertUrl("https://selectpdf.com");
        doc.Save("webpage-print.pdf");
        doc.Close();
    }
}
