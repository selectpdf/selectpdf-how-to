using SelectPdf.Universal;

// 1. Make a three-page report to render.
HtmlToPdf converter = new HtmlToPdf();
PdfDocument report = converter.ConvertHtmlString("""
    <h1 style="color: #1f6feb">Quarterly report</h1><p>Revenue, costs and forecast.</p>
    <h2 style="page-break-before: always">Costs</h2><p>Details by department.</p>
    <h2 style="page-break-before: always">Forecast</h2><p>Next quarter.</p>
    """);
report.Save("report.pdf");
report.Close();

// 2. Load the PDF into the PDF to image converter and set the resolution.
var rasterizer = new PdfRasterizer();
rasterizer.Load("report.pdf");
rasterizer.Resolution = 150;

// 3. Render every page to PNG: one byte array per page.
byte[][] pages = rasterizer.ConvertToImages();
for (int i = 0; i < pages.Length; i++)
{
    File.WriteAllBytes($"page-{i + 1}.png", pages[i]);
}
