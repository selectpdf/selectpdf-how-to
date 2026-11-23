using SelectPdf.Universal;

static class ValidationLimits
{
    public static void Run()
    {
        byte[] pdf = File.ReadAllBytes("annual-report.pdf");

        // list at most 3 failures per rule, and give the validation 10 seconds
        var options = new ValidationOptions(MaxFailuresPerRule: 3, Timeout: TimeSpan.FromSeconds(10));
        ValidationReport report = PdfValidator.Validate(pdf, null, PdfConformanceStandard.PdfA2B, options);
        Console.WriteLine($"{report.Failures.Count} failures listed, {report.ChecksFailed} checks failed, " +
            $"complete: {report.Complete}");

        // a yes-or-no check: stop at the first failure
        ValidationReport quick = PdfValidator.Validate(pdf, null, PdfConformanceStandard.PdfA2B,
            new ValidationOptions(MaxFailures: 1));
        Console.WriteLine($"compliant: {quick.IsCompliant}, complete: {quick.Complete}, " +
            $"{quick.Failures.Count} failure listed");
        if (!quick.Complete)
            Console.WriteLine("The validation stopped early, so the report is not compliant.");
    }
}
