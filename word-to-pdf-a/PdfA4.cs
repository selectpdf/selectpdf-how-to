using SelectPdf.Universal;

static class PdfA4
{
    public static void Run()
    {
        WordToPdf converter = new WordToPdf();

        // PDF/A-4 is the archiving level defined on PDF 2.0
        converter.Options.PdfStandard = PdfStandard.PdfA4;
        converter.Options.PdfDocumentInformation.Title = "Board meeting minutes, October 2026";

        PdfDocument doc = converter.ConvertFile("board-minutes.docx");
        doc.Save("board-minutes-pdfa4.pdf");
        doc.Close();
    }
}
