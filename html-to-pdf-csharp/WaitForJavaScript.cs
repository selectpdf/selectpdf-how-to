using SelectPdf.Universal;

static class WaitForJavaScript
{
    public static void Run()
    {
        // content that a script adds half a second after the page loads, like a chart or a data grid
        string html = """
            <h1>Sales report</h1>
            <div id="chart">loading...</div>
            <script>
              setTimeout(() => document.getElementById("chart").textContent = "Q3 revenue: 1.2M", 500);
            </script>
            """;

        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.ConversionDelay = 2;      // seconds to wait after the page loads
        converter.Options.NavigationTimeout = 30;   // seconds before a page that never loads fails

        PdfDocument doc = converter.ConvertHtmlString(html);
        doc.Save("report.pdf");
        doc.Close();
    }
}
