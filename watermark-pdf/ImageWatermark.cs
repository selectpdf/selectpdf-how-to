using SelectPdf.Universal;

static class ImageWatermark
{
    public static void Run()
    {
        // a logo as PNG bytes (in your application, File.ReadAllBytes("logo.png"))
        HtmlToImage imager = new HtmlToImage();
        imager.WebPageWidth = 400;
        imager.WebPageHeight = 120;
        byte[] logo = imager.ConvertHtmlString(
            "<div style='font: bold 64px sans-serif; color: #1a4fa0'>ACME Corp</div>");

        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument doc = converter.ConvertHtmlString("""
            <h1>Price list</h1><p>Valid until the end of the year.</p>
            <h2 style="page-break-before: always">Terms</h2><p>Payment within 30 days.</p>
            """);

        // the logo, 300 points wide, in the middle of every page, behind the content
        var area = doc.Pages[0].ClientRectangle;
        PdfTemplate watermark = doc.Templates.Add(area);
        watermark.Background = true;
        PdfImageElement img = new PdfImageElement((area.Width - 300) / 2, area.Height / 2 - 45, 300, logo);
        img.Transparency = 25;
        watermark.Add(img);

        doc.Save("price-list-watermarked.pdf");
        doc.Close();
    }
}
