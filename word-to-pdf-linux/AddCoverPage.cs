using SelectPdf.Universal;

static class AddCoverPage
{
    public static void Run()
    {
        // a cover page made from HTML
        HtmlToPdf html = new HtmlToPdf();
        PdfDocument cover = html.ConvertHtmlString("""
            <div style="font-family: Arial; margin-top: 300px; text-align: center">
              <h1>Contoso Ltd</h1>
              <p>Board pack, October 2026</p>
            </div>
            """);

        // the Word document, converted straight into a PdfDocument
        PdfDocument report = new WordToPdf().ConvertFile("report.docx");

        // append both to a new document; they stay open until it is saved
        PdfDocument pack = new PdfDocument();
        pack.Append(cover);
        pack.Append(report);
        pack.Save("board-pack.pdf");

        pack.Close();
        cover.Close();
        report.Close();
    }
}
