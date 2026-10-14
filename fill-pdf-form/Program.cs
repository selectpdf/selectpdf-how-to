using SelectPdf.Universal;

// an HTML form: every control has a name
string html = """
    <style>body { font-family: Arial, sans-serif; }</style>
    <h1>Conference registration</h1>
    <form>
      <p><label>Full name <input type="text" name="fullName"></label></p>
      <p><label>Email <input type="email" name="email"></label></p>
      <p><label>Ticket
        <select name="ticket">
          <option value="standard">Standard</option>
          <option value="workshop">Workshop</option>
          <option value="vip">VIP</option>
        </select></label></p>
      <p>Meal:
        <label><input type="radio" name="meal" value="regular"> Regular</label>
        <label><input type="radio" name="meal" value="vegetarian"> Vegetarian</label></p>
      <p><label><input type="checkbox" name="newsletter"> Send me the newsletter</label></p>
    </form>
    """;

// convert it into a fillable PDF form
HtmlToPdf converter = new HtmlToPdf();
converter.Options.CreateFormFields = true;
PdfDocument doc = converter.ConvertHtmlString(html);
doc.Save("registration-form.pdf");
doc.Close();

// load the form and fill the fields by name
PdfFormManager form = new PdfFormManager();
form.Load("registration-form.pdf");

((PdfFormFieldTextBox)form.Fields["fullName"]).Text = "Jane Doe";
((PdfFormFieldTextBox)form.Fields["email"]).Text = "jane.doe@example.com";
((PdfFormFieldComboBox)form.Fields["ticket"]).SelectedValue = "workshop";
((PdfFormFieldRadioButtonList)form.Fields["meal"]).SelectedValue = "vegetarian";
((PdfFormFieldCheckBox)form.Fields["newsletter"]).Checked = true;

// save the filled form
form.Save("registration-filled.pdf");
form.Close();
