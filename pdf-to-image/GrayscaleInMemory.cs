using SelectPdf.Universal;

static class GrayscaleInMemory
{
    public static void Run()
    {
        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument doc = converter.ConvertHtmlString("<h1>Scanned letter</h1><p>Black text on white.</p>");
        byte[] pdf = doc.Save(); // the PDF as bytes, e.g. from a database or an upload
        doc.Close();

        // load from a stream and render in shades of gray
        var rasterizer = new PdfRasterizer();
        rasterizer.Load(new MemoryStream(pdf));
        rasterizer.ColorSpace = PdfRasterizerColorSpace.Gray;
        byte[][] pages = rasterizer.ConvertToImages();

        // each page is an encoded PNG: write it to any stream (a response body, blob storage...)
        using FileStream file = File.Create("letter-gray.png");
        file.Write(pages[0]);
    }
}
