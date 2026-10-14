using SelectPdf.Universal;

static class MergeDocxIntoPdfA
{
    public static void Run()
    {
        WordToPdf converter = new WordToPdf();
        converter.Options.PdfStandard = PdfStandard.PdfA2B;

        PdfDocument minutes = converter.ConvertFile("board-minutes.docx");
        PdfDocument resolution = converter.ConvertFile("board-resolution.docx");

        // the target declares PDF/A-2b and accepts only PDF/A-2 sources
        PdfDocument archive = new PdfDocument(PdfStandard.PdfA2B);
        archive.DocumentInformation.Title = "Board meeting of 8 October 2026";
        archive.Append(minutes);
        archive.Append(resolution);
        archive.Save("board-meeting-pdfa2b.pdf");

        archive.Close();
        minutes.Close();
        resolution.Close();
    }
}
