using SelectPdf.Universal;

static class MergeConvertedPages
{
    public static void Run()
    {
        // convert straight into documents, no temporary files
        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument cover = converter.ConvertHtmlString("<h1>Annual report</h1><p>Cover page</p>");
        PdfDocument body = converter.ConvertHtmlString("<h2>Results</h2><p>Revenue grew in every region.</p>");

        PdfDocument report = new PdfDocument();
        report.Append(cover);
        report.Append(body);
        report.Save("report.pdf");

        // appended documents must stay open until the merged document is saved
        report.Close();
        cover.Close();
        body.Close();
    }
}
