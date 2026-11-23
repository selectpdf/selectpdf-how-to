using SelectPdf.Universal;

PdfSanitizeManager sanitizer = new PdfSanitizeManager();
sanitizer.Load("untrusted.pdf");

// scan: report what the document holds, change nothing
PdfSanitizeReport found = sanitizer.Scan();
Console.WriteLine($"Active content: {found.HasActiveContent}");
foreach (PdfSanitizeFinding finding in found.Findings)
    Console.WriteLine(finding);

// remove scripts, actions, embedded files, multimedia, XFA, hidden layers and private data
sanitizer.Options = PdfSanitizeOptions.Default;
PdfSanitizeReport removed = sanitizer.Sanitize();
Console.WriteLine($"Removed {removed.Findings.Count} items");

sanitizer.Save("sanitized.pdf");
sanitizer.Close();
