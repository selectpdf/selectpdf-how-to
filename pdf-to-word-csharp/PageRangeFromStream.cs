using SelectPdf.Universal;

static class PageRangeFromStream
{
    public static void Run()
    {
        PdfToWord converter = new PdfToWord();

        // only pages 2 and 3; "1", "2-4" and "1-3,5,7-" work too
        converter.Options.PageRanges = "2-3";

        // ConvertStream reads the PDF from the stream's current position
        using FileStream pdf = File.OpenRead("report.pdf");
        byte[] docx = converter.ConvertStream(pdf);
        File.WriteAllBytes("report-pages-2-3.docx", docx);
    }
}
