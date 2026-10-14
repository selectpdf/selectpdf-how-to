using SelectPdf.Universal;
using SelectPdf.Universal.Drawing;

static class NumberExistingPdf
{
    public static void Run()
    {
        // an existing PDF without page numbers (made here so the sample runs on its own)
        HtmlToPdf converter = new HtmlToPdf();
        string rows = string.Concat(Enumerable.Range(1, 120).Select(i => $"<p>Line item {i}</p>"));
        PdfDocument source = converter.ConvertHtmlString($"<h1>Report</h1>{rows}");
        source.Save("unnumbered.pdf");
        source.Close();

        // shrink the content to free 40 points at the bottom of every page
        PdfResizeManager resizer = new PdfResizeManager();
        resizer.Load("unnumbered.pdf");
        resizer.PageMargins = new PdfMargins(0, 0, 0, 40);
        PdfDocument doc = resizer.GetDocument();

        // a template docked in that space repeats on every page
        float width = doc.Pages[0].ClientRectangle.Width;
        float height = doc.Pages[0].ClientRectangle.Height;
        PdfTemplate footer = doc.Templates.Add(new RectangleF(0, height - 40, width, 40));

        PdfFont font = doc.Fonts.Add(PdfStandardFont.Helvetica);
        font.Size = 9;
        footer.Add(new PdfTextElement(width - 90, 14, "Page {page_number} of {total_pages}", font));

        doc.Save("numbered.pdf");
        resizer.Close();
    }
}
