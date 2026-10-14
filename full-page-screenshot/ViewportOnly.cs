using SelectPdf.Universal;

static class ViewportOnly
{
    public static void Run()
    {
        // Setting a height crops the image to that height: only the first
        // 1280 x 800 px of the page, what a visitor sees before scrolling.
        HtmlToImage converter = new HtmlToImage();
        converter.WebPageWidth = 1280;
        converter.WebPageHeight = 800;

        byte[] png = converter.ConvertUrl("https://selectpdf.com");
        File.WriteAllBytes("first-screen.png", png);
    }
}
