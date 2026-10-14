using SelectPdf.Universal;

static class RedactKnownText
{
    public static void Run()
    {
        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument contract = converter.ConvertHtmlString("""
            <h1>Supply agreement</h1>
            <p>Between Contoso Ltd and Fabrikam Inc.</p>
            <p>Contoso Ltd delivers 400 units per month.</p>
            """);
        contract.Save("contract.pdf");
        contract.Close();

        var redactor = new PdfRedactionManager();
        redactor.Load("contract.pdf");
        redactor.FillColor = new PdfColor(128, 128, 128);

        // exact text: case-sensitive, whole words only
        redactor.AddRedaction("Contoso Ltd", true, true);

        // Redact returns what was removed, for an audit log
        foreach (PdfRedactionResult r in redactor.Redact())
            Console.WriteLine($"page {r.PageIndex + 1}: {r.Text}");

        redactor.Save("contract-redacted.pdf");
        redactor.Close();
    }
}
