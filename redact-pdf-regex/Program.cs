using System.Text.RegularExpressions;
using SelectPdf.Universal;

// 1. Make a statement that contains card numbers.
HtmlToPdf converter = new HtmlToPdf();
PdfDocument statement = converter.ConvertHtmlString("""
    <h1>Card statement</h1>
    <p>Primary card: 4111-1111-1111-1111</p>
    <p>Backup card: 5500-0000-0000-0004</p>
    """);
statement.Save("statement.pdf");
statement.Close();

// 2. Remove every card number from the file.
var redactor = new PdfRedactionManager();
redactor.Load("statement.pdf");
redactor.AddRedaction(new Regex(@"\d{4}-\d{4}-\d{4}-\d{4}"));
redactor.OverlayText = "REDACTED";
redactor.Redact();
redactor.Save("statement-redacted.pdf");
redactor.Close();
