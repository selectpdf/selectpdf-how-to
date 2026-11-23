using SelectPdf.Universal;

static class ClaimedStandard
{
    public static void Run()
    {
        // check each file at the level it declares in its metadata
        foreach (string file in new[] { "annual-report.pdf", "annual-report-pdfa2b.pdf" })
        {
            byte[] pdf = File.ReadAllBytes(file);
            PdfConformanceStandard? claimed = PdfValidator.ClaimedStandard(pdf, null);
            if (claimed == null)
            {
                Console.WriteLine($"{file}: claims no standard");
                continue;
            }

            ValidationReport report = PdfValidator.Validate(pdf, null, claimed.Value);
            Console.WriteLine($"{file}: claims {claimed}, " +
                (report.IsCompliant ? "compliant" : $"not compliant, {report.ChecksFailed} checks failed"));
        }
    }
}
