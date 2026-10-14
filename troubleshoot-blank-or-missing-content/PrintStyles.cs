using SelectPdf.Universal;

static class PrintStyles
{
    public static void Run()
    {
        // the terms are hidden on screen and shown only by the print styles
        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.CssMediaType = HtmlToPdfCssMediaType.Print;

        PdfDocument doc = converter.ConvertHtmlString("""
            <style>
              .print-only { display: none; }
              @media print {
                .print-only { display: block; }
                .screen-only { display: none; }
              }
            </style>
            <h1>Invoice #1042</h1>
            <p class="screen-only">Pay online with the button below.</p>
            <p class="print-only">Payment terms: 30 days from the invoice date.</p>
            """);
        doc.Save("invoice-print.pdf");
        doc.Close();
    }
}
