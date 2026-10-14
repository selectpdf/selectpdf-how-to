using SelectPdf.Universal;

static class MobileWidth
{
    public static void Run()
    {
        // A 390 px wide window, the width of a phone screen. The page's
        // responsive CSS applies, and the height stays auto (full page).
        HtmlToImage converter = new HtmlToImage();
        converter.WebPageWidth = 390;

        byte[] png = converter.ConvertUrl("https://selectpdf.com");
        File.WriteAllBytes("full-page-mobile.png", png);
    }
}
