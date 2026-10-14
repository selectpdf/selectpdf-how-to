using SelectPdf.Universal;

static class FlattenAndProtect
{
    public static void Run()
    {
        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.CreateFormFields = true;
        PdfDocument doc = converter.ConvertHtmlString("""
            <h1>Expense claim</h1>
            <form>
              <p>Employee: <input name="employee" style="width:300px"></p>
              <p>Amount: <input name="amount" style="width:150px"></p>
            </form>
            """);

        PdfFormManager form = new PdfFormManager();
        form.Load(doc);
        ((PdfFormFieldTextBox)form.Fields["employee"]).Text = "Jane Doe";
        ((PdfFormFieldTextBox)form.Fields["amount"]).Text = "412.50";
        form.Flatten = true;

        // GetDocument returns the flattened result as a PdfDocument, ready for security settings
        PdfDocument flattened = form.GetDocument();
        string ownerPassword = Environment.GetEnvironmentVariable("PDF_OWNER_PASSWORD") ?? "owner-change-me";
        flattened.Security.OwnerPassword = ownerPassword;
        flattened.Security.CanEditContent = false;
        flattened.Save("expense-claim-protected.pdf");

        flattened.Close();
        form.Close();
        doc.Close();
    }
}
