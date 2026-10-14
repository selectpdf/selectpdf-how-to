using SelectPdf.Universal;

static class FirstPageThumbnail
{
    public static void Run()
    {
        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument doc = converter.ConvertHtmlString("""
            <h1>Product catalog</h1><p>Spring collection.</p>
            <h2 style="page-break-before: always">Prices</h2><p>All items.</p>
            """);

        // load the document straight from memory, no file in between
        var rasterizer = new PdfRasterizer();
        rasterizer.Load(doc);

        // only page 1, at 72 DPI for a small preview
        rasterizer.StartPageNumber = 1;
        rasterizer.EndPageNumber = 1;
        rasterizer.Resolution = 72;
        byte[][] pages = rasterizer.ConvertToImages();
        File.WriteAllBytes("thumbnail.png", pages[0]);
        doc.Close();
    }
}
