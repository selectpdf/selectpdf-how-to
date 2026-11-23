using SelectPdf.Universal;

// load the dynamic XFA form: its fields come from its XFA template
PdfFormManager form = new PdfFormManager();
form.Load("xfa-form.pdf");
Console.WriteLine($"XFA form: {form.IsXfaForm}, {form.Fields.Count} fields");

// a field is found by its path in the form, or by its own name
((PdfFormFieldTextBox)form.Fields["form1.Page1.Name"]).Text = "Jane Doe";

// a date is set as the form keeps it: yyyy-MM-dd
((PdfFormFieldTextBox)form.Fields["BirthDate"]).Text = "1985-03-14";

// setting the quantity runs the form's own calculation of the total
((PdfFormFieldTextBox)form.Fields["Quantity"]).Text = "4";
((PdfFormFieldComboBox)form.Fields["Delivery"]).SelectedValue = "EXP";
((PdfFormFieldCheckBox)form.Fields["Agree"]).Checked = true;

// FormattedValue is the value as the form shows it
Console.WriteLine($"Total: {form.Fields["Total"].FormattedValue}");

// save it as the same dynamic form, still fillable
form.Save("xfa-form-filled.pdf");

// and as the pages it lays out, with the values and no form
form.Flatten = true;
form.Save("xfa-form-flattened.pdf");
form.Close();
