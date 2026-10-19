using SelectPdf.Universal;

static class CorporateFont
{
    public static void Run()
    {
        // the font file ships with the application (Fraunces, SIL Open Font License);
        // @font-face loads it by a relative path, resolved against the base URL
        string html = """
            <style>
              @font-face { font-family: "Brand"; src: url("Fraunces-SemiBold.ttf"); }
              h1 { font-family: "Brand", serif; font-size: 40px; }
            </style>
            <h1>Quarterly report</h1>
            <p style="font-family: sans-serif">The heading uses the company font on every server.</p>
            """;

        string folder = Path.GetFullPath(".") + Path.DirectorySeparatorChar;
        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument doc = converter.ConvertHtmlString(html, new Uri(folder).AbsoluteUri);
        doc.Save("brand-font.pdf");
        doc.Close();
    }
}
