using SelectPdf.Universal;

static class AccessiblePdfUA1
{
    public static void Run()
    {
        byte[] pdf = File.ReadAllBytes("annual-report.pdf");

        // tag the document for PDF/UA-1; the language is set from the options, never guessed
        PreflightResult result = PdfPreflight.Fix(pdf, null, PdfConformanceStandard.PdfUA1,
            new PreflightOptions(Language: "en-GB"));
        foreach (PreflightFix fix in result.Applied)
            Console.WriteLine($"Fixed: {fix.Description}");

        // what needs a person is still reported: the chart has no alternative text
        foreach (RuleFailure failure in result.After.Failures)
            Console.WriteLine($"Left for a person: {failure.Rule}: {failure.Message}");

        // describe the chart, the one figure without a description
        using PdfAccessibilityManager manager = new PdfAccessibilityManager();
        manager.Load(result.Pdf);
        PdfFigure chart = manager.MissingAlternateText[0];
        chart.AlternateText = "Bar chart of revenue by quarter in 2026, in thousands of euros: " +
            "Q1 820, Q2 910, Q3 1,040 and Q4 1,150.";
        byte[] described = manager.Save();

        // validate again
        ValidationReport report = PdfValidator.Validate(described, null, PdfConformanceStandard.PdfUA1);
        Console.WriteLine($"PDF/UA-1: {(report.IsCompliant ? "compliant" : "not compliant")}");
        if (report.IsCompliant)
            File.WriteAllBytes("annual-report-ua1.pdf", described);
    }
}
