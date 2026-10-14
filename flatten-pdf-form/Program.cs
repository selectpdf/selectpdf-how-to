using SelectPdf.Universal;

// 1. Create a fillable form: CreateFormFields turns the HTML controls into PDF form fields.
HtmlToPdf converter = new HtmlToPdf();
converter.Options.CreateFormFields = true;
PdfDocument doc = converter.ConvertHtmlString("""
    <h1>Membership application</h1>
    <form>
      <p>Name: <input name="name" style="width:300px"></p>
      <p>Email: <input type="email" name="email" style="width:300px"></p>
      <p>Plan: <select name="plan">
        <option>Basic</option><option>Premium</option></select></p>
      <p><input type="checkbox" name="terms"> I accept the terms</p>
    </form>
    """);

// 2. Fill the fields by name.
PdfFormManager form = new PdfFormManager();
form.Load(doc);
((PdfFormFieldTextBox)form.Fields["name"]).Text = "Jane Doe";
((PdfFormFieldTextBox)form.Fields["email"]).Text = "jane.doe@example.com";
((PdfFormFieldComboBox)form.Fields["plan"]).SelectedValue = "Premium";
((PdfFormFieldCheckBox)form.Fields["terms"]).Checked = true;

// 3. Flatten the whole form and write a new, compact file.
form.Flatten = true;
form.CompactSave = true;
form.Save("application-flattened.pdf");
form.Close();
doc.Close();

// 4. Check: the flattened file has no form fields left.
PdfFormManager check = new PdfFormManager();
check.Load("application-flattened.pdf");
Console.WriteLine($"Form fields left: {check.Fields.Count}");
check.Close();
