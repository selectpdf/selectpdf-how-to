using SelectPdf.Universal;

static class PdfToPowerPointSlides
{
    public static void Run()
    {
        PdfToPowerPoint converter = new PdfToPowerPoint();

        // the PDF's tables become PowerPoint tables (the default)
        converter.Options.Tables = true;

        // a PDF already in memory: a slide per page
        byte[] pdf = File.ReadAllBytes("quarterly-review.pdf");
        byte[] pptx = converter.ConvertBytes(pdf);
        File.WriteAllBytes("quarterly-review.pptx", pptx);
    }
}
