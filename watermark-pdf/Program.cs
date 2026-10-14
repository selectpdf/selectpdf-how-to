using SelectPdf.Universal;

// 1. Make a three-page report to stamp.
HtmlToPdf converter = new HtmlToPdf();
PdfDocument report = converter.ConvertHtmlString("""
    <h1>Quarterly report</h1><p>Revenue, costs and forecast.</p>
    <h2 style="page-break-before: always">Costs</h2><p>Details by department.</p>
    <h2 style="page-break-before: always">Forecast</h2><p>Next quarter.</p>
    """);
report.Save("report.pdf");
report.Close();

// 2. Load the PDF and add a template that covers the whole page.
PdfDocument doc = new PdfDocument("report.pdf");
var area = doc.Pages[0].ClientRectangle;
PdfTemplate stamp = doc.Templates.Add(area);

// 3. A large red text, rotated 45 degrees and semi-transparent.
PdfFont font = doc.Fonts.Add(PdfStandardFont.HelveticaBold);
font.Size = 72;
string label = "CONFIDENTIAL";
float width = font.GetTextWidth(label);
float side = width * 0.7071f; // the rotated text spans width * cos 45 each way
PdfTextElement text = new PdfTextElement((area.Width - side) / 2, (area.Height + side) / 2,
    width + 1, label, font, new PdfColor(220, 0, 0));
text.Direction = 45;
text.Transparency = 30;
stamp.Add(text);

// 4. The template repeats on every page. Save the stamped copy.
doc.Save("report-watermarked.pdf");
doc.Close();
