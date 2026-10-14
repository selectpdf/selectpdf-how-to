using SelectPdf.Universal;

HtmlToPdf converter = new HtmlToPdf();

// A4 portrait with 20 mm margins (margins are in points: 20 mm = 57 pt)
converter.Options.PdfPageSize = PdfPageSize.A4;
converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
converter.Options.MarginTop = 57;
converter.Options.MarginBottom = 57;
converter.Options.MarginLeft = 57;
converter.Options.MarginRight = 57;

// 1. a web page, by URL
PdfDocument page = converter.ConvertUrl("https://selectpdf.com");
page.Save("webpage.pdf");
page.Close();

// 2. an HTML string; the base URL resolves relative images, styles and links
string html = """
    <img src="img/selectpdf-logo-h128.png" alt="SelectPdf" height="40">
    <h1>Invoice #1042</h1>
    <p>Issued to Contoso Ltd on 12 October 2026.</p>
    """;
PdfDocument invoice = converter.ConvertHtmlString(html, "https://selectpdf.com/");
invoice.Save("invoice.pdf");
invoice.Close();
