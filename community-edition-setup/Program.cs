using SelectPdf.Universal;

// 1. The free Community Edition (SelectPdf.HtmlToPdf.Universal) has the same
// HtmlToPdf converter and options as the commercial library.
HtmlToPdf converter = new HtmlToPdf();
converter.Options.PdfPageSize = PdfPageSize.A4;
converter.Options.MarginTop = 20;
converter.Options.MarginBottom = 20;

// 2. Headers and footers are included: "Page X of Y" at the bottom right.
converter.Options.DisplayFooter = true;
converter.Footer.Height = 30;
PdfTextSection pageNumbers = new PdfTextSection(0, 8, "Page {page_number} of {total_pages}  ",
    PdfFont.CreateFromSystemFont("Liberation Sans", 9f));
pageNumbers.HorizontalAlign = PdfTextHorizontalAlign.Right;
converter.Footer.Add(pageNumbers);

// 3. Convert a web page and save the PDF.
PdfDocument doc = converter.ConvertUrl("https://selectpdf.com/community-edition/");
doc.Save("community-edition.pdf");
doc.Close();

// 4. A document keeps at most 5 pages: check whether the content was longer.
HtmlToPdfResult result = converter.ConversionResult;
Console.WriteLine($"{result.PdfPageCount} pages saved, {result.PdfPageCountBeforeLimit} before the limit");
