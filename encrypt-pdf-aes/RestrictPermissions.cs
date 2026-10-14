using SelectPdf.Universal;

static class RestrictPermissions
{
    public static void Run()
    {
        string userPassword = Environment.GetEnvironmentVariable("PDF_USER_PASSWORD") ?? "open-me";
        string ownerPassword = Environment.GetEnvironmentVariable("PDF_OWNER_PASSWORD") ?? "owner-change-me";

        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument doc = converter.ConvertHtmlString("<h1>Contract draft</h1><p>For review only.</p>");

        // the user password opens the file; the owner password changes the permissions
        doc.Security.UserPassword = userPassword;
        doc.Security.OwnerPassword = ownerPassword;

        // no printing, no copying, no editing
        doc.Security.CanPrint = false;
        doc.Security.CanCopyContent = false;
        doc.Security.CanEditContent = false;

        doc.Save("contract-restricted.pdf");
        doc.Close();
    }
}
