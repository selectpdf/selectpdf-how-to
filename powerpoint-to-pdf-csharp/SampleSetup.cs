// Not part of the guide: applies your license key from the SELECTPDF_LICENSE_KEY environment variable,
// so the samples run unchanged. Without a key the output carries the trial watermark.
using System.Runtime.CompilerServices;

internal static class SampleSetup
{
    [ModuleInitializer]
    internal static void Init()
    {
        var key = Environment.GetEnvironmentVariable("SELECTPDF_LICENSE_KEY");
        if (!string.IsNullOrWhiteSpace(key)) SelectPdf.Universal.GlobalProperties.LicenseKey = key;
    }
}
