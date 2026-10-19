using System.Text;
using SelectPdf.Universal;

static class LongInvoice
{
    public static void Run()
    {
        // 80 lines: the table runs over several pages
        StringBuilder rows = new StringBuilder();
        for (int i = 1; i <= 80; i++)
            rows.Append($"<tr><td>Support ticket #{4100 + i}</td><td class=\"num\">{i % 4 + 1}</td><td class=\"num\">75.00</td></tr>");

        string html = $$"""
            <style>
              body { font-family: sans-serif; }
              table { width: 100%; border-collapse: collapse; }
              th { background: #1d4ed8; color: #fff; text-align: left; padding: 6px; }
              td { border-bottom: 1px solid #ddd; padding: 6px; }
              .num { text-align: right; }
            </style>
            <h1>Invoice 2026-119</h1>
            <table>
              <thead style="display: table-header-group">
                <tr><th>Item</th><th class="num">Hours</th><th class="num">Rate</th></tr>
              </thead>
              <tbody>{{rows}}</tbody>
            </table>
            """;

        HtmlToPdf converter = new HtmlToPdf();
        // the table header repeats on every page when rendered with the print media type
        converter.Options.CssMediaType = HtmlToPdfCssMediaType.Print;

        // "Page X of Y" in the footer of every page
        converter.Options.DisplayFooter = true;
        converter.Footer.Height = 30;
        PdfTextSection pageNumbers = new PdfTextSection(0, 8, "Invoice 2026-119, page {page_number} of {total_pages}",
            PdfFont.CreateFromSystemFont("Liberation Sans", 9f));
        pageNumbers.HorizontalAlign = PdfTextHorizontalAlign.Right;
        converter.Footer.Add(pageNumbers);

        PdfDocument doc = converter.ConvertHtmlString(html);
        doc.Save("invoice-2026-119.pdf");
        doc.Close();
    }
}
