using SelectPdf.Universal;

// 1. The password readers type to open the file.
//    Read it from a secret store or the environment; never commit a real one.
string userPassword = Environment.GetEnvironmentVariable("PDF_USER_PASSWORD") ?? "open-me";

// 2. Create the PDF.
HtmlToPdf converter = new HtmlToPdf();
PdfDocument doc = converter.ConvertHtmlString("""
    <h1>Payslip</h1>
    <p>Employee: Jane Doe</p>
    <p>Net pay: 3,250.00</p>
    """);

// 3. Encrypt it with AES-256 (these two lines are the defaults, written out).
doc.Security.Algorithm = PdfEncryptionAlgorithm.AES;
doc.Security.KeySize = PdfEncryptionKeySize.EncryptKey256BitRevision6;
doc.Security.UserPassword = userPassword;

// 4. Save and close.
doc.Save("payslip-protected.pdf");
doc.Close();
