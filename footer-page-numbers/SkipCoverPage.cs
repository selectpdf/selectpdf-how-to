using SelectPdf.Universal;

static class SkipCoverPage
{
    public static void Run()
    {
        HtmlToPdf converter = new HtmlToPdf();

        // HTML header on every page except the cover
        converter.Options.DisplayHeader = true;
        converter.Header.Height = 30;
        converter.Header.DisplayOnFirstPage = false;
        converter.Header.Add(new PdfHtmlSection(
            "<div style='font: 10px sans-serif; color: #555; padding-top: 10px'>Quarterly report</div>", ""));

        // footer: page number on every page except the cover, which still counts as page 1
        converter.Options.DisplayFooter = true;
        converter.Footer.Height = 40;
        converter.Footer.DisplayOnFirstPage = false;
        PdfTextSection pageNumbers = new PdfTextSection(0, 10,
            "Page {page_number} of {total_pages}  ",
            PdfFont.CreateFromSystemFont("Liberation Sans", 9f));
        pageNumbers.HorizontalAlign = PdfTextHorizontalAlign.Right;
        converter.Footer.Add(pageNumbers);

        string rows = string.Concat(Enumerable.Range(1, 120).Select(i => $"<p>Line item {i}</p>"));
        string html = $"<h1 style='page-break-after: always'>Quarterly report</h1>{rows}";

        PdfDocument doc = converter.ConvertHtmlString(html);
        doc.Save("report-with-cover.pdf");
        doc.Close();
    }
}
