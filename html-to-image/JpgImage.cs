using SelectPdf.Universal;

static class JpgImage
{
    public static void Run()
    {
        HtmlToImage converter = new HtmlToImage(1024, 768);

        // the bytes come back already encoded as JPEG
        converter.ImageFormat = PdfImageFormat.Jpeg;

        byte[] jpg = converter.ConvertUrl("https://selectpdf.com/pdf-library/");
        File.WriteAllBytes("library.jpg", jpg);
    }
}
