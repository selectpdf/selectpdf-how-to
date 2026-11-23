using SelectPdf.Universal;

static class AccessiblePdfUa
{
    public static void Run()
    {
        PowerPointToPdf converter = new PowerPointToPdf();

        // PDF/A-3a is archival and accessible: it turns tagging on by itself
        converter.Options.PdfStandard = PdfStandard.PdfA3A;

        // declare PDF/UA-1, which needs a title and a language
        converter.Options.AccessibilityStandard = PdfUAStandard.UA1;
        converter.Options.Title = "Quarterly review";
        converter.Options.Language = "en-US";

        // the slides from memory, for example an upload
        byte[] pptx = File.ReadAllBytes("presentation.pptx");
        PdfDocument doc = converter.ConvertBytes(pptx);
        doc.Save("presentation-pdfa3a-ua1.pdf");
        doc.Close();
    }
}
