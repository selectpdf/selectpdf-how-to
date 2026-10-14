using System.Text;
using SelectPdf.Universal;

static class PdfA3bWithSource
{
    public static void Run()
    {
        string csv = "Region,Revenue\nEurope,1200000\nAmericas,900000\n";

        HtmlToPdf converter = new HtmlToPdf();

        // PDF/A-3 is the level that may carry embedded files
        converter.Options.PdfStandard = PdfStandard.PdfA3B;
        converter.Options.PdfDocumentInformation.Title = "Revenue by region";

        PdfDocument doc = converter.ConvertHtmlString(
            "<h1>Revenue by region</h1><p>Europe: 1,200,000<br>Americas: 900,000</p>");

        // embed the data the report was built from, as an associated file
        using (MemoryStream data = new MemoryStream(Encoding.UTF8.GetBytes(csv)))
        {
            doc.AddAssociatedFile(data, "revenue.csv", PdfAttachmentRelationship.Source,
                "text/csv", "Revenue data");
            doc.Save("revenue-pdfa3b.pdf");
        }

        doc.Close();
    }
}
