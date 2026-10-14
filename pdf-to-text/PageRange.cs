using SelectPdf.Universal;

static class PageRange
{
    public static void Run()
    {
        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument book = converter.ConvertHtmlString("""
            <h1>Chapter 1</h1><p>The first chapter.</p>
            <h1 style="page-break-before: always">Chapter 2</h1><p>The second chapter.</p>
            <h1 style="page-break-before: always">Chapter 3</h1><p>The third chapter.</p>
            <h1 style="page-break-before: always">Chapter 4</h1><p>The fourth chapter.</p>
            """);
        book.Save("book.pdf");
        book.Close();

        PdfToText pdfToText = new PdfToText();
        pdfToText.Load("book.pdf");
        Console.WriteLine($"{pdfToText.GetPageCount()} pages");

        // one page: page numbers start at 1
        Console.WriteLine(pdfToText.GetText(1));

        // pages 2 to 3, with a form feed at the end of each page
        pdfToText.StartPageNumber = 2;
        pdfToText.EndPageNumber = 3;
        pdfToText.MarkPageBreaks = true;
        pdfToText.SaveText("book-pages-2-3.txt");
        pdfToText.Close();
    }
}
