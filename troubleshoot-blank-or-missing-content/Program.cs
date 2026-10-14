using SelectPdf.Universal;

// A report whose totals are written by a script 1.5 seconds after the page
// has loaded, the way a chart or a fetch() call fills in a page.
string html = """
    <h1>Quarterly report</h1>
    <p>Sales for July to September 2026.</p>
    <div id="totals">Loading totals...</div>
    <script>
      setTimeout(() => {
        document.getElementById("totals").innerHTML =
          "<h2>Totals</h2><p>Revenue: 1,284,500 EUR</p><p>Orders: 9,312</p>";
      }, 1500);
    </script>
    """;

HtmlToPdf converter = new HtmlToPdf();

// By default the page is captured as soon as it has loaded, so the PDF
// shows "Loading totals...". Wait 3 more seconds for the script to run.
converter.Options.ConversionDelay = 3;

PdfDocument doc = converter.ConvertHtmlString(html);
doc.Save("report.pdf");
doc.Close();
