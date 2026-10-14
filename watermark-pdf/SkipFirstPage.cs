using SelectPdf.Universal;
using SelectPdf.Universal.Drawing;

static class SkipFirstPage
{
    public static void Run()
    {
        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument doc = converter.ConvertHtmlString("""
            <h1>Cover page</h1>
            <h2 style="page-break-before: always">Section 1</h2>
            <h2 style="page-break-before: always">Section 2</h2>
            """);

        // a small stamp in the top-right corner of every page except the cover
        var area = doc.Pages[0].ClientRectangle;
        PdfTemplate stamp = doc.Templates.Add(new RectangleF(area.Width - 130, 10, 120, 40));
        stamp.DisplayOnFirstPage = false;

        PdfFont font = doc.Fonts.Add(PdfStandardFont.HelveticaBold);
        font.Size = 24;
        PdfTextElement text = new PdfTextElement(0, 5, 120, "COPY", font, new PdfColor(0, 90, 200));
        text.HorizontalAlign = PdfTextHorizontalAlign.Center;
        stamp.Add(text);

        doc.Save("report-copy.pdf");
        doc.Close();
    }
}
