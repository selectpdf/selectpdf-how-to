using SelectPdf.Universal;

static class WaitForScripts
{
    public static void Run()
    {
        // This section is added by a script one second after the page loads.
        string html = """
            <h1>Sales dashboard</h1>
            <div id="report"><p>Loading...</p></div>
            <script>
              setTimeout(() => {
                document.getElementById("report").innerHTML =
                  "<h2>Totals</h2>" + "<p>Region data.</p>".repeat(40);
              }, 1000);
            </script>
            """;

        // Wait 2 seconds after the load event, so the screenshot includes it.
        HtmlToImage converter = new HtmlToImage();
        converter.WebPageWidth = 1024;
        converter.ConversionDelay = 2;

        byte[] png = converter.ConvertHtmlString(html);
        File.WriteAllBytes("dashboard.png", png);
    }
}
