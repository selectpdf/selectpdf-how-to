using SelectPdf.Universal;

static class ExcelInPageRegion
{
    public static void Run()
    {
        PdfDocument doc = new PdfDocument();
        PdfPage page = doc.AddPage();

        PdfFont titleFont = PdfFont.CreateStandardFont(PdfStandardFont.HelveticaBold, 20);
        page.Add(new PdfTextElement(0, 0, "Annex B - the sales figures", titleFont, new PdfColor(44, 62, 80)));

        // the Sales sheet in a 500 x 400 pt box, 60 pt down the page, fitted on one page
        PdfExcelElement sales = new PdfExcelElement(0, 60, 500, 400, "sales.xlsx");
        sales.Worksheets = "Sales";
        sales.Layout = ExcelLayout.FitSheetOnOnePage;
        page.Add(sales);

        doc.Save("sales-annex.pdf");
        doc.Close();
    }
}
