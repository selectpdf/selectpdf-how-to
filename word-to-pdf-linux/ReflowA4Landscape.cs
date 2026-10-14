using SelectPdf.Universal;

static class ReflowA4Landscape
{
    public static void Run()
    {
        WordToPdf converter = new WordToPdf();

        // Options: reflow the text onto A4 landscape with one-inch (72 pt) margins
        converter.Options.PageSetup = WordPageSetup.Options;
        converter.Options.PdfPageSize = PdfPageSize.A4;
        converter.Options.PdfPageOrientation = PdfPageOrientation.Landscape;
        converter.Options.MarginTop = 72;
        converter.Options.MarginBottom = 72;
        converter.Options.MarginLeft = 72;
        converter.Options.MarginRight = 72;

        // page numbers in a footer band
        converter.Options.DisplayFooter = true;
        converter.Footer.Height = 30;
        converter.Footer.Add(new PdfTextSection(0, 10, 500, "Page {page_number} of {total_pages}",
            PdfFont.CreateStandardFont(PdfStandardFont.Helvetica, 9), new PdfColor(80, 80, 80)));

        PdfDocument doc = converter.ConvertFile("report.docx");
        doc.Save("report-a4-landscape.pdf");
        doc.Close();
    }
}
