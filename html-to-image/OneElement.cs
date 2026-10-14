using SelectPdf.Universal;

static class OneElement
{
    public static void Run()
    {
        string html = """
            <h1>Monthly report</h1>
            <p>Only the table below goes into the image.</p>
            <table id="totals" border="1" cellpadding="8" style="border-collapse:collapse">
              <tr><th>Region</th><th>Orders</th></tr>
              <tr><td>Europe</td><td>1,240</td></tr>
              <tr><td>Americas</td><td>980</td></tr>
            </table>
            """;

        HtmlToImage converter = new HtmlToImage(800);

        // capture only the element the CSS selector matches
        converter.VisibleWebElementSelector = "#totals";

        byte[] png = converter.ConvertHtmlString(html);
        File.WriteAllBytes("totals.png", png);
    }
}
