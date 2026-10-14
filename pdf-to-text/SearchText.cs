using SelectPdf.Universal;

static class SearchText
{
    public static void Run()
    {
        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument invoice = converter.ConvertHtmlString("""
            <h1>Invoice 1042</h1>
            <p>Subtotal: 400.00</p><p>Tax: 76.00</p><p>Total: 476.00</p>
            """);
        invoice.Save("invoice.pdf");
        invoice.Close();

        PdfToText pdfToText = new PdfToText();
        pdfToText.Load("invoice.pdf");

        // case-insensitive, not limited to whole words: matches "Subtotal" and "Total"
        TextPosition[] hits = pdfToText.Search("total", false, false);
        pdfToText.Close();

        // highlight every match on a copy of the PDF
        PdfDocument doc = new PdfDocument("invoice.pdf");
        foreach (TextPosition hit in hits)
        {
            Console.WriteLine($"page {hit.PageNumber} at {hit.X}, {hit.Y}");
            PdfRectangleElement box = new PdfRectangleElement(hit.X, hit.Y, hit.Width, hit.Height);
            box.BackColor = new PdfColor(240, 240, 0);
            box.Transparency = 30;
            doc.Pages[hit.PageNumber - 1].Add(box);
        }
        doc.Save("invoice-highlighted.pdf");
        doc.Close();
    }
}
