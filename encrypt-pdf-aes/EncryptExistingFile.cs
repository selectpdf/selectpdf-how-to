using SelectPdf.Universal;

static class EncryptExistingFile
{
    public static void Run()
    {
        // a PDF that already exists (here made on the spot)
        PdfDocument report = new HtmlToPdf().ConvertHtmlString("<h1>Annual report</h1>");
        report.Save("report.pdf");
        report.Close();

        string userPassword = Environment.GetEnvironmentVariable("PDF_USER_PASSWORD") ?? "open-me";
        string ownerPassword = Environment.GetEnvironmentVariable("PDF_OWNER_PASSWORD") ?? "owner-change-me";

        // PdfSecurityManager encrypts an existing file (AES-256, revision 6, by default)
        var security = new PdfSecurityManager();
        security.Load("report.pdf");
        security.UserPassword = userPassword;
        security.OwnerPassword = ownerPassword;
        security.Save("report-protected.pdf");
        security.Close();

        // open it again with the password
        PdfDocument check = new PdfDocument("report-protected.pdf", userPassword);
        Console.WriteLine($"Opened with the password: {check.Pages.Count} page(s)");
        check.Close();
    }
}
