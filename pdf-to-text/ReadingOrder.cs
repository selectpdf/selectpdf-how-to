using SelectPdf.Universal;

static class ReadingOrder
{
    public static void Run()
    {
        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument article = converter.ConvertHtmlString("""
            <div style="display: flex; gap: 40px; width: 500px">
              <p style="flex: 1">The left column starts the story. It runs over several lines.</p>
              <p style="flex: 1">The right column ends the story. It should come second.</p>
            </div>
            """);
        article.Save("article.pdf");
        article.Close();

        PdfToText pdfToText = new PdfToText();
        pdfToText.Load("article.pdf");

        // Original (the default) keeps the columns side by side
        Console.WriteLine(pdfToText.GetText());

        // Reading returns one column after the other
        pdfToText.Layout = TextLayout.Reading;
        pdfToText.SaveText("article.txt");
        pdfToText.Close();
    }
}
