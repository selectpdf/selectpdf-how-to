using SelectPdf.Universal;

static class WideContent
{
    public static void Run()
    {
        // six 300-pixel columns: wider than the 1,024-pixel web page, so by
        // default the Total column is cut, as a browser cuts it when it prints
        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.FitWideContent = true; // lay out at full width, scale to fit

        PdfDocument doc = converter.ConvertHtmlString("""
            <style>th { min-width: 300px; }</style>
            <h1>Stock by warehouse</h1>
            <table border="1" style="border-collapse: collapse">
              <tr><th>Item</th><th>Berlin</th><th>Lyon</th>
                  <th>Milan</th><th>Vienna</th><th>Total</th></tr>
              <tr><td>Laptop stand</td><td>120</td><td>85</td>
                  <td>64</td><td>40</td><td>309</td></tr>
            </table>
            """);
        doc.Save("wide-table.pdf");
        doc.Close();
    }
}
