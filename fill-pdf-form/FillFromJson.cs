using System.Text.Json;
using SelectPdf.Universal;

static class FillFromJson
{
    public static void Run()
    {
        // a blank form (made here so the sample runs on its own)
        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.CreateFormFields = true;
        PdfDocument doc = converter.ConvertHtmlString("""
            <h1>Shipping label</h1>
            <p><label>Recipient <input type="text" name="recipient"></label></p>
            <p><label>City <input type="text" name="city"></label></p>
            <p><label>Service <select name="service">
                <option value="standard">Standard</option><option value="express">Express</option>
              </select></label></p>
            <p><label><input type="checkbox" name="fragile"> Fragile</label></p>
            """);
        doc.Save("shipping-label-form.pdf");
        doc.Close();

        // the values, keyed by field name, as they arrive from an API or a database
        string json = """
            { "recipient": "Contoso Ltd", "city": "Berlin", "service": "express", "fragile": "true" }
            """;
        Dictionary<string, string> values = JsonSerializer.Deserialize<Dictionary<string, string>>(json)!;

        // set each field from the value with its name
        PdfFormManager form = new PdfFormManager();
        form.Load("shipping-label-form.pdf");
        foreach (PdfFormField field in form.Fields)
        {
            if (!values.TryGetValue(field.Name, out string? value)) continue;
            switch (field)
            {
                case PdfFormFieldTextBox text: text.Text = value; break;
                case PdfFormFieldCheckBox check: check.Checked = bool.Parse(value); break;
                case PdfFormFieldComboBox combo: combo.SelectedValue = value; break;
                case PdfFormFieldRadioButtonList radio: radio.SelectedValue = value; break;
            }
        }
        form.Save("shipping-label-filled.pdf");
        form.Close();
    }
}
