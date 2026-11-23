using SelectPdf.Universal;

static class MarkdownOutput
{
    public static void Run()
    {
        PdfToWord converter = new PdfToWord();

        // Markdown: headings, lists and links as Markdown, tables as pipe tables
        converter.Options.Format = PdfToWordFormat.Markdown;

        byte[] md = converter.ConvertFile("report.pdf");
        File.WriteAllBytes("report.md", md);
    }
}
