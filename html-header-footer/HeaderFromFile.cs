using SelectPdf.Universal;

static class HeaderFromFile
{
    public static void Run()
    {
        // the header lives in its own HTML file, maintained with the rest of your templates
        File.WriteAllText("header.html", """
            <div style="padding: 16px 40px; border-bottom: 3px solid #c2410c; font: bold 28px sans-serif">
              Acme Ltd. Sales report
            </div>
            """);

        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.DisplayHeader = true;
        converter.Header.Height = 60;

        // a section built from a URL renders that page: here a file:// URL of the local file
        string url = new Uri(Path.GetFullPath("header.html")).AbsoluteUri;
        converter.Header.Add(new PdfHtmlSection(url));

        string rows = string.Concat(Enumerable.Range(1, 120).Select(i => $"<p>Line item {i}</p>"));
        PdfDocument doc = converter.ConvertHtmlString($"<h1>Report</h1>{rows}");
        doc.Save("header-from-file.pdf");
        doc.Close();
    }
}
