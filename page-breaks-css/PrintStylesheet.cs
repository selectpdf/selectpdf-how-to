using SelectPdf.Universal;

static class PrintStylesheet
{
    public static void Run()
    {
        // page breaks only in the print stylesheet, so the page reads normally on screen
        string html = """
            <style>
              @media print { h2 { page-break-before: always; } }
            </style>
            <h1>User guide</h1>
            <h2>Installation</h2><p>Install the package.</p>
            <h2>Configuration</h2><p>Set the options.</p>
            """;

        // render with the @media print styles instead of the screen styles
        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.CssMediaType = HtmlToPdfCssMediaType.Print;
        PdfDocument doc = converter.ConvertHtmlString(html);
        doc.Save("user-guide.pdf");
        doc.Close();
    }
}
