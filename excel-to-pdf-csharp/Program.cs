using SelectPdf.Universal;

ExcelToPdf converter = new ExcelToPdf();

// every sheet keeps its own paper and margins; all its columns fit the width of a page
converter.Options.Layout = ExcelLayout.FitAllColumnsOnOnePage;

// the title recorded in the generated document
converter.Options.PdfDocumentInformation.Title = "Quarterly sales by region";

// the format is taken from the file extension; every visible sheet is converted
PdfDocument doc = converter.ConvertFile("sales.xlsx");
Console.WriteLine($"{converter.ConversionResult.PdfPageCount} pages, {doc.Bookmarks.Count} sheets in the outline");

doc.Save("sales.pdf");
doc.Close();
