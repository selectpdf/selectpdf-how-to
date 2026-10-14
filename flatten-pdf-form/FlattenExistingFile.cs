using SelectPdf.Universal;

static class FlattenExistingFile
{
    public static void Run()
    {
        // a fillable PDF that already exists (here made on the spot)
        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.CreateFormFields = true;
        PdfDocument blank = converter.ConvertHtmlString("""
            <h1>Delivery note</h1>
            <form>
              <p>Received by: <input name="receiver" style="width:300px"></p>
              <p><input type="checkbox" name="complete"> Delivery complete</p>
            </form>
            """);
        blank.Save("delivery-note.pdf");
        blank.Close();

        // load the file, fill it and flatten it into a new file
        PdfFormManager form = new PdfFormManager();
        form.Load("delivery-note.pdf");
        ((PdfFormFieldTextBox)form.Fields["receiver"]).Text = "John Smith";
        ((PdfFormFieldCheckBox)form.Fields["complete"]).Checked = true;
        form.Flatten = true;
        form.CompactSave = true;
        form.Save("delivery-note-final.pdf");
        form.Close();
    }
}
