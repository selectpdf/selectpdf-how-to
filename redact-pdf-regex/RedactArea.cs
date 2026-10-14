using SelectPdf.Universal;
using SelectPdf.Universal.Drawing;

static class RedactArea
{
    public static void Run()
    {
        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument form = converter.ConvertHtmlString("""
            <h1>Application form</h1>
            <p>Name: Jane Doe</p>
            <p>Signature: ____________________</p>
            """);
        form.Save("form.pdf");
        form.Close();

        var redactor = new PdfRedactionManager();
        redactor.Load("form.pdf");

        // a fixed area on page 1 (x, y, width, height in points from the top-left corner)
        redactor.AddRedaction(0, new RectangleF(0, 60, 300, 50));
        redactor.Redact();

        // in memory: Save() returns the redacted PDF as bytes
        byte[] pdf = redactor.Save();
        redactor.Close();
        File.WriteAllBytes("form-redacted.pdf", pdf);
    }
}
