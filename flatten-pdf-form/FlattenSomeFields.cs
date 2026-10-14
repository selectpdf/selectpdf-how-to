using SelectPdf.Universal;

static class FlattenSomeFields
{
    public static void Run()
    {
        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.CreateFormFields = true;
        PdfDocument doc = converter.ConvertHtmlString("""
            <h1>Membership renewal</h1>
            <form>
              <p>Member: <input name="name" style="width:300px"></p>
              <p>Member number: <input name="number" style="width:300px"></p>
              <p>Plan: <select name="plan">
                <option>Basic</option><option>Premium</option></select></p>
              <p><input type="checkbox" name="terms"> I accept the terms</p>
            </form>
            """);

        PdfFormManager form = new PdfFormManager();
        form.Load(doc);

        // fill in what you already know and flatten only those fields
        PdfFormField name = form.Fields["name"];
        ((PdfFormFieldTextBox)name).Text = "Jane Doe";
        name.Flatten = true;

        PdfFormField number = form.Fields["number"];
        ((PdfFormFieldTextBox)number).Text = "M-10442";
        number.Flatten = true;

        // "plan" and "terms" stay fillable for the member
        form.Save("renewal-prefilled.pdf");
        form.Close();
        doc.Close();
    }
}
