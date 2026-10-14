using SelectPdf.Universal;

static class FirstPageHeader
{
    public static void Run()
    {
        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.DisplayHeader = true;
        converter.Header.Height = 60;
        converter.Header.Add(new PdfHtmlSection(
            "<div style='padding: 20px 40px; font: 20px sans-serif; color: #555'>Acme Ltd. Sales report</div>", ""));

        string rows = string.Concat(Enumerable.Range(1, 120).Select(i => $"<p>Line item {i}</p>"));
        PdfDocument doc = converter.ConvertHtmlString($"<h1>Report</h1>{rows}");

        // page 1 gets its own header: a template as wide as the page and as tall as the header
        PdfPage first = doc.Pages[0];
        PdfTemplate cover = doc.AddTemplate(first.PageSize.Width, 60);
        cover.Add(new PdfHtmlElement(
            "<div style='padding: 12px 40px; background: #c2410c; color: white; font: bold 32px sans-serif'>" +
            "Acme Ltd. Sales report</div>", ""));
        first.CustomHeader = cover;

        doc.Save("first-page-header.pdf");
        doc.Close();
    }
}
