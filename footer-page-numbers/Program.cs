using SelectPdf.Universal;

HtmlToPdf converter = new HtmlToPdf();

// footer with "Page X of Y", right-aligned
converter.Options.DisplayFooter = true;
converter.Footer.Height = 40;

PdfTextSection pageNumbers = new PdfTextSection(0, 10,
    "Page {page_number} of {total_pages}  ",
    PdfFont.CreateFromSystemFont("Liberation Sans", 9f));
pageNumbers.HorizontalAlign = PdfTextHorizontalAlign.Right;
converter.Footer.Add(pageNumbers);

// enough content for three pages
string rows = string.Concat(Enumerable.Range(1, 120).Select(i => $"<p>Line item {i}</p>"));
PdfDocument doc = converter.ConvertHtmlString($"<h1>Report</h1>{rows}");
doc.Save("report.pdf");
doc.Close();
