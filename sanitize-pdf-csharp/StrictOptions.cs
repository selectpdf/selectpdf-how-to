using SelectPdf.Universal;

static class StrictOptions
{
    public static void Run()
    {
        using PdfSanitizeManager sanitizer = new PdfSanitizeManager();
        sanitizer.Load("untrusted.pdf");

        // the default set, plus web links and the document information and XMP metadata
        sanitizer.Options = PdfSanitizeOptions.Default
            | PdfSanitizeOptions.ExternalLinks
            | PdfSanitizeOptions.Metadata;

        PdfSanitizeReport removed = sanitizer.Sanitize();
        foreach (PdfSanitizeFinding finding in removed.Findings)
            Console.WriteLine($"Removed {finding}");

        // the sanitized document as bytes, ready to store or return
        byte[] pdf = sanitizer.Save();
        File.WriteAllBytes("sanitized-strict.pdf", pdf);
    }
}
