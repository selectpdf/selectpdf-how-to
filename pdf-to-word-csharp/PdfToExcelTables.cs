using SelectPdf.Universal;

static class PdfToExcelTables
{
    public static void Run()
    {
        PdfToExcel converter = new PdfToExcel();

        // a worksheet per table (the default), numbers read as US figures
        converter.Options.Sheets = PdfToExcelSheets.PerTable;
        converter.Options.Culture = "en-US";

        byte[] xlsx = converter.ConvertFile("sales-by-region.pdf");
        File.WriteAllBytes("sales-by-region.xlsx", xlsx);
    }
}
