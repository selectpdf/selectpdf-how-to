using SelectPdf.Universal;

static class RefuseActiveContent
{
    public static void Run()
    {
        foreach (string upload in new[] { "untrusted.pdf", "price-list.pdf" })
        {
            // an upload arrives as bytes; Scan only reads it
            using PdfSanitizeManager sanitizer = new PdfSanitizeManager();
            sanitizer.Load(File.ReadAllBytes(upload));
            PdfSanitizeReport found = sanitizer.Scan();

            if (found.HasActiveContent)
            {
                int scripts = found.Count(PdfSanitizeOptions.JavaScript);
                int files = found.Count(PdfSanitizeOptions.EmbeddedFiles);
                Console.WriteLine($"{upload}: refused (JavaScript: {scripts}, embedded files: {files})");
                continue;
            }

            Console.WriteLine($"{upload}: accepted");
            File.Copy(upload, "accepted-" + upload, overwrite: true);
        }
    }
}
