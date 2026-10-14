using System.Text;
using SelectPdf.Universal;

static class RepeatTableHeaders
{
    public static void Run()
    {
        // a table long enough to run over several pages
        StringBuilder rows = new StringBuilder();
        for (int i = 1; i <= 120; i++)
            rows.Append($"<tr><td>Order {1000 + i}</td><td>${i * 25}</td></tr>");

        string html = $"""
            <table style="width: 100%; border-collapse: collapse;">
              <thead style="display: table-header-group;">
                <tr><th align="left">Order</th><th align="left">Amount</th></tr>
              </thead>
              <tbody>{rows}</tbody>
            </table>
            """;

        // the header row repeats at the top of every page with the print media type
        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.CssMediaType = HtmlToPdfCssMediaType.Print;
        PdfDocument doc = converter.ConvertHtmlString(html);
        doc.Save("orders.pdf");
        doc.Close();
    }
}
