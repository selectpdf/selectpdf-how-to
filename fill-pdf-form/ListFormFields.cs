using SelectPdf.Universal;

static class ListFormFields
{
    public static void Run()
    {
        // a form that already holds values (made here so the sample runs on its own)
        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.CreateFormFields = true;
        PdfDocument doc = converter.ConvertHtmlString("""
            <form>
              <input type="text" name="company" value="Contoso Ltd">
              <textarea name="notes">Deliver to the side entrance.</textarea>
              <input type="checkbox" name="express" checked>
              <input type="radio" name="payment" value="card">
              <input type="radio" name="payment" value="invoice" checked>
              <select name="country"><option>France</option><option selected>Germany</option></select>
              <select name="extras" multiple>
                <option selected>Gift wrap</option><option>Insurance</option><option selected>Tracking</option>
              </select>
            </form>
            """);

        // list every field: name, type and current value
        PdfFormManager form = new PdfFormManager();
        form.Load(doc);
        List<string> lines = new List<string>();
        foreach (PdfFormField field in form.Fields)
        {
            string value = field switch
            {
                PdfFormFieldTextBox text => text.Text,
                PdfFormFieldCheckBox check => check.Checked.ToString(),
                PdfFormFieldRadioButtonList radio => radio.SelectedValue,
                PdfFormFieldComboBox combo => combo.SelectedValue,
                PdfFormFieldListBox list => string.Join(", ", list.SelectedValues),
                _ => ""
            };
            lines.Add($"{field.Name} ({field.GetType().Name}, page {field.DisplayPage}): {value}");
        }
        form.Close();
        doc.Close();

        File.WriteAllLines("form-fields.txt", lines);
        lines.ForEach(Console.WriteLine);
    }
}
