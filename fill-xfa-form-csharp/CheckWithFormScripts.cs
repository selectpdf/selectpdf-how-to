using SelectPdf.Universal;

static class CheckWithFormScripts
{
    public static void Run()
    {
        PdfFormManager form = new PdfFormManager();
        form.Load("xfa-form.pdf");

        // a value the form's validation refuses: its message is in ScriptMessages
        PdfFormFieldTextBox quantity = (PdfFormFieldTextBox)form.Fields["Quantity"];
        quantity.Text = "0";

        // correct it and fill the rest
        quantity.Text = "2";
        ((PdfFormFieldTextBox)form.Fields["Name"]).Text = "Jane Doe";
        ((PdfFormFieldCheckBox)form.Fields["Agree"]).Checked = true;

        // press the form's own Check button: its click script runs
        form.Click(form.Fields["Check"]);

        // what the form's scripts reported, and the scripts that failed
        List<string> lines = new List<string>();
        foreach (string message in form.ScriptMessages)
            lines.Add("message: " + message);
        foreach (string error in form.ScriptErrors)
            lines.Add("error: " + error);
        form.Close();

        File.WriteAllLines("xfa-form-messages.txt", lines);
        lines.ForEach(Console.WriteLine);
    }
}
