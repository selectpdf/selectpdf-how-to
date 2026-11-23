using SelectPdf.Universal;

static class AccessiblePdfA3a
{
    public static void Run()
    {
        ExcelToPdf converter = new ExcelToPdf();

        // PDF/A-3a is archival and accessible: it turns tagging on by itself
        converter.Options.PdfStandard = PdfStandard.PdfA3A;

        // declare PDF/UA-1, which needs a title and a language
        converter.Options.AccessibilityStandard = PdfUAStandard.UA1;
        converter.Options.Title = "Quarterly sales by region";
        converter.Options.Language = "en-US";

        PdfDocument doc = converter.ConvertFile("sales.xlsx");
        doc.Save("sales-pdfa3a-ua1.pdf");
        doc.Close();
    }
}
