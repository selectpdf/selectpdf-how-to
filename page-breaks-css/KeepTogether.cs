using SelectPdf.Universal;

static class KeepTogether
{
    public static void Run()
    {
        // tall blocks: without a rule, some of them would be split across two pages
        string cards = "";
        for (int i = 1; i <= 8; i++)
            cards += $"""<div class="card"><h3>Customer {i}</h3><p>Account summary for customer {i}.</p></div>""";

        // page-break-inside: avoid moves a block that does not fit to the next page
        string html = $$"""
            <style>
              .card { height: 300px; border: 1px solid #999; margin-bottom: 20px; page-break-inside: avoid; }
            </style>
            {{cards}}
            """;

        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument doc = converter.ConvertHtmlString(html);
        doc.Save("customers.pdf");
        doc.Close();
    }
}
