using SelectPdf.Universal;

static class FillAndLock
{
    public static void Run()
    {
        // a blank form (made here so the sample runs on its own)
        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.CreateFormFields = true;
        PdfDocument doc = converter.ConvertHtmlString("""
            <h1>Leave request</h1>
            <p><label>Employee <input type="text" name="employee"></label></p>
            <p><label>From <input type="text" name="from"></label>
               <label>To <input type="text" name="to"></label></p>
            <p><label><input type="checkbox" name="approved"> Approved</label></p>
            """);
        byte[] blank = doc.Save();
        doc.Close();

        // fill the form from memory, then make every field read-only
        PdfFormManager form = new PdfFormManager();
        form.Load(blank);
        ((PdfFormFieldTextBox)form.Fields["employee"]).Text = "Jane Doe";
        ((PdfFormFieldTextBox)form.Fields["from"]).Text = "2026-11-02";
        ((PdfFormFieldTextBox)form.Fields["to"]).Text = "2026-11-06";
        ((PdfFormFieldCheckBox)form.Fields["approved"]).Checked = true;
        form.ReadOnly = true;

        form.Save("leave-request-locked.pdf");
        form.Close();
    }
}
