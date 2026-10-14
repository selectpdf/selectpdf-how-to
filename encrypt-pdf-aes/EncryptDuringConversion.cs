using SelectPdf.Universal;

static class EncryptDuringConversion
{
    public static void Run()
    {
        string userPassword = Environment.GetEnvironmentVariable("PDF_USER_PASSWORD") ?? "open-me";
        string ownerPassword = Environment.GetEnvironmentVariable("PDF_OWNER_PASSWORD") ?? "owner-change-me";

        // set the security on the converter: every PDF it produces is encrypted
        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.SecurityOptions.UserPassword = userPassword;
        converter.Options.SecurityOptions.OwnerPassword = ownerPassword;
        converter.Options.SecurityOptions.CanCopyContent = false;

        PdfDocument doc = converter.ConvertUrl("https://selectpdf.com");
        doc.Save("page-protected.pdf");
        doc.Close();
    }
}
