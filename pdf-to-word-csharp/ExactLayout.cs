using SelectPdf.Universal;

static class ExactLayout
{
    public static void Run()
    {
        PdfToWord converter = new PdfToWord();

        // Exact: every page reproduced as it is, each block of text at its place
        converter.Options.Layout = PdfToWordLayout.Exact;

        byte[] docx = converter.ConvertFile("report.pdf");
        File.WriteAllBytes("report-exact.docx", docx);
    }
}
