using SelectPdf.Universal;

static class OneSheetOnA4
{
    public static void Run()
    {
        ExcelToPdf converter = new ExcelToPdf();

        // lay the sheet out on the page set here, not on its own paper
        converter.Options.PageSetup = ExcelPageSetup.Options;
        converter.Options.PdfPageSize = PdfPageSize.A4;
        converter.Options.PdfPageOrientation = PdfPageOrientation.Landscape;
        converter.Options.MarginLeft = 30;
        converter.Options.MarginRight = 30;
        converter.Options.MarginTop = 30;
        converter.Options.MarginBottom = 30;

        // only the Sales sheet, scaled to fit on one page
        converter.Options.Worksheets = "Sales";
        converter.Options.Layout = ExcelLayout.FitSheetOnOnePage;

        // a page-number footer; a width of -1 spans the whole band
        converter.Options.DisplayFooter = true;
        converter.Footer.Height = 30;
        PdfTextSection pageNumbers = new PdfTextSection(0, 10, -1, "Page {page_number} of {total_pages}",
            PdfFont.CreateStandardFont(PdfStandardFont.Helvetica, 9), new PdfColor(80, 80, 80));
        pageNumbers.HorizontalAlign = PdfTextHorizontalAlign.Center;
        converter.Footer.Add(pageNumbers);

        PdfDocument doc = converter.ConvertFile("sales.xlsx");
        doc.Save("sales-sheet-a4.pdf");
        doc.Close();
    }
}
