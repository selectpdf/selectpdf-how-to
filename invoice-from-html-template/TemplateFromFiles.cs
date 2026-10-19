using System.Net;
using SelectPdf.Universal;

static class TemplateFromFiles
{
    public static void Run()
    {
        // the template and its stylesheet are files a designer can edit;
        // the base URL lets the HTML load invoice.css by a relative path
        string folder = Path.GetFullPath(".") + Path.DirectorySeparatorChar;
        string html = File.ReadAllText("invoice-template.html")
            .Replace("{{number}}", WebUtility.HtmlEncode("2026-120"))
            .Replace("{{customer}}", WebUtility.HtmlEncode("Northwind Traders & Co"))
            .Replace("{{total}}", 980.00m.ToString("N2"));

        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument doc = converter.ConvertHtmlString(html, new Uri(folder).AbsoluteUri);
        doc.Save("invoice-2026-120.pdf");
        doc.Close();
    }
}
