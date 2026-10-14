using SelectPdf.Universal;

static class MergeIntoPdfA
{
    public static void Run()
    {
        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.PdfStandard = PdfStandard.PdfA2B;

        PdfDocument cover = converter.ConvertHtmlString("<h1>Case file 2026-31</h1>");
        PdfDocument body = converter.ConvertHtmlString("<h2>Correspondence</h2><p>Letter of 2 October 2026.</p>");

        // the target declares PDF/A-2b and accepts only PDF/A-2 sources
        PdfDocument archive = new PdfDocument(PdfStandard.PdfA2B);
        archive.Append(cover);
        archive.Append(body);
        archive.Save("case-file-pdfa2b.pdf");

        archive.Close();
        cover.Close();
        body.Close();
    }
}
