using SelectPdf.Universal;

static class HandoutsOnA4
{
    public static void Run()
    {
        PowerPointToPdf converter = new PowerPointToPdf();

        // two slides on each page, the slides scaled onto A4 portrait pages
        converter.Options.Publish = PowerPointPublish.Handouts;
        converter.Options.SlidesPerHandout = 2;
        converter.Options.PageSetup = PowerPointPageSetup.Options;
        converter.Options.PdfPageSize = PdfPageSize.A4;
        converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;

        // a centered page-number footer; a width of -1 spans the whole band
        converter.Options.DisplayFooter = true;
        converter.Footer.Height = 30;
        PdfTextSection pageNumbers = new PdfTextSection(0, 8, -1, "Page {page_number} of {total_pages}",
            PdfFont.CreateStandardFont(PdfStandardFont.Helvetica, 9), new PdfColor(80, 80, 80));
        pageNumbers.HorizontalAlign = PdfTextHorizontalAlign.Center;
        converter.Footer.Add(pageNumbers);

        PdfDocument doc = converter.ConvertFile("presentation.pptx");
        doc.Save("presentation-handouts.pdf");
        doc.Close();
    }
}
