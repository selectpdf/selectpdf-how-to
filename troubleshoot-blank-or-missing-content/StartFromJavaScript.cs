using SelectPdf.Universal;

static class StartFromJavaScript
{
    public static void Run()
    {
        // the page tells the converter when it is ready: no fixed delay to guess
        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.StartupMode = HtmlToPdfStartupMode.Manual;
        converter.Options.NavigationTimeout = 30; // fails if selectpdf.start() is never called

        PdfDocument doc = converter.ConvertHtmlString("""
            <h1>Order summary</h1>
            <div id="items">Loading items...</div>
            <script>
              setTimeout(() => {
                document.getElementById("items").innerHTML =
                  "<p>3 x Laptop stand</p><p>1 x USB-C dock</p>";
                if (typeof selectpdf == "object") selectpdf.start();
              }, 2000);
            </script>
            """);
        doc.Save("order-summary.pdf");
        doc.Close();
    }
}
