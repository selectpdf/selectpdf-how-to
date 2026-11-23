using SelectPdf.Universal;

// the PDF to check: an ordinary PDF, made with no archiving standard in mind
byte[] pdf = File.ReadAllBytes("annual-report.pdf");

// 1. validate it against PDF/A-2b; the file is only read, never changed
ValidationReport report = PdfValidator.Validate(pdf, null, PdfConformanceStandard.PdfA2B);
Console.WriteLine($"PDF/A-2b: {(report.IsCompliant ? "compliant" : "not compliant")}, " +
    $"{report.ChecksPassed} checks passed, {report.ChecksFailed} failed");

// one line per failed rule, with where its first failing object is
foreach (var rule in report.Failures.GroupBy(failure => failure.Rule))
{
    RuleFailure first = rule.First();
    string where = first.Page is int page ? $"page {page}" : first.Context;
    Console.WriteLine($"  {rule.Key} ({rule.Count()}x): {first.Message} [{where}]");
}

// 2. fix it for PDF/A-2b; the fixed document is validated again
PreflightResult result = PdfPreflight.Fix(pdf, null, PdfConformanceStandard.PdfA2B);
foreach (PreflightFix fix in result.Applied)
    Console.WriteLine($"Fixed: {fix.Description}");

// 3. keep the fixed document only when it now conforms
Console.WriteLine($"After the fix: {(result.After.IsCompliant ? "compliant" : "not compliant")}");
foreach (RuleFailure failure in result.After.Failures)
    Console.WriteLine($"  still failing: {failure.Rule}: {failure.Message}");
if (result.After.IsCompliant)
    File.WriteAllBytes("annual-report-pdfa2b.pdf", result.Pdf);
