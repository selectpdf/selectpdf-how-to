using SelectPdf.Universal;

static class RegionsAtOnce
{
    public static async Task Run()
    {
        // one document, two web pages rendered into it at the same time
        PdfDocument doc = new PdfDocument();
        PdfPage page1 = doc.AddPage();
        PdfPage page2 = doc.AddPage();

        Task<PdfRenderingResult> first = page1.AddAsync(new PdfHtmlElement("https://selectpdf.com"));
        Task<PdfRenderingResult> second = page2.AddAsync(new PdfHtmlElement("https://selectpdf.com/pricing/"));

        // an element placed below the first region waits for that region
        PdfRenderingResult result = await first;
        PdfFont font = doc.Fonts.Add(PdfStandardFont.Helvetica);
        font.Size = 10;
        await page1.AddAsync(new PdfTextElement(0, result.PdfPageLastRectangle.Bottom + 10, "Captured with SelectPdf", font));
        await second;

        doc.Save("two-pages.pdf");
        doc.Close();
    }
}
