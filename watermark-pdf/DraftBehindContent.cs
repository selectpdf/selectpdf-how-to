using SelectPdf.Universal;

static class DraftBehindContent
{
    public static void Run()
    {
        // stamp the converter output before saving it: no second file needed
        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument doc = converter.ConvertHtmlString("""
            <h1>Contract draft</h1>
            <p style="font-size: 32px">The parties agree to the terms below.
            The text stays readable on top of the DRAFT label.</p>
            """);

        var area = doc.Pages[0].ClientRectangle;
        PdfTemplate draft = doc.Templates.Add(area);
        draft.Background = true; // behind the page content; the default is in front

        PdfFont font = doc.Fonts.Add(PdfStandardFont.HelveticaBold);
        font.Size = 160;
        PdfTextElement text = new PdfTextElement(0, 20, area.Width, "DRAFT", font, new PdfColor(200, 200, 200));
        text.HorizontalAlign = PdfTextHorizontalAlign.Center;
        draft.Add(text);

        doc.Save("contract-draft.pdf");
        doc.Close();
    }
}
