using SelectPdf.Universal;

static class WebFontFromUrl
{
    public static void Run()
    {
        // a web font from a font service: the engine downloads it like a browser does
        string html = """
            <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Lobster&display=swap">
            <h1 style="font-family: 'Lobster', cursive; font-size: 44px">Summer sale</h1>
            <p style="font-family: sans-serif">Loaded from Google Fonts during the conversion.</p>
            """;

        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument doc = converter.ConvertHtmlString(html);
        doc.Save("web-font.pdf");
        doc.Close();
    }
}
