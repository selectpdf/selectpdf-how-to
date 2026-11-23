using SelectPdf.Universal;

static class ListXfaFields
{
    public static void Run()
    {
        PdfFormManager form = new PdfFormManager();
        form.Load("xfa-form.pdf");

        // what each field shows the user: its caption, tooltip and whether it is required
        List<string> lines = new List<string>();
        foreach (PdfFormField field in form.Fields)
        {
            lines.Add($"{field.FullName} ({field.GetType().Name})");
            lines.Add($"  caption: {field.Caption}, required: {field.Required}, read-only: {field.ReadOnly}");
            if (field.ToolTip != null)
                lines.Add($"  tooltip: {field.ToolTip}");
            if (!string.IsNullOrEmpty(field.FormattedValue))
                lines.Add($"  shows: {field.FormattedValue}");

            // a drop-down list: the values it keeps and the texts it shows
            if (field is PdfFormFieldComboBox list)
                lines.Add($"  values: {string.Join(", ", list.Items)} ({string.Join(", ", list.ItemTexts)})");
        }
        form.Close();

        File.WriteAllLines("xfa-form-fields.txt", lines);
        lines.ForEach(Console.WriteLine);
    }
}
