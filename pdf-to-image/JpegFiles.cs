using SelectPdf.Universal;

static class JpegFiles
{
    public static void Run()
    {
        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument doc = converter.ConvertHtmlString("""
            <h1>Photo album</h1><p>Summer trip.</p>
            <h2 style="page-break-before: always">Day two</h2><p>The coast.</p>
            """);
        doc.Save("album.pdf");
        doc.Close();

        // Save() writes one file per page into ImagesPath, named ImagesPrefix + page number
        var rasterizer = new PdfRasterizer();
        rasterizer.Load("album.pdf");
        rasterizer.ImagesFormat = PdfImageFormat.Jpeg;
        Directory.CreateDirectory("album-pages"); // the folder must exist
        rasterizer.ImagesPath = "album-pages";
        rasterizer.ImagesPrefix = "page-";
        rasterizer.Save();
    }
}
