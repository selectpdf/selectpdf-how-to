using SelectPdf.Universal;

static class RasterizePages
{
    public static void Run()
    {
        using PdfSanitizeManager sanitizer = new PdfSanitizeManager();
        sanitizer.Load("untrusted.pdf");

        // every page becomes an image of itself: nothing of the original is kept, its text included
        sanitizer.Rasterize = true;
        sanitizer.Resolution = 200;

        PdfSanitizeReport removed = sanitizer.Sanitize();
        Console.WriteLine($"Removed {removed.Findings.Count} items");
        sanitizer.Save("rasterized.pdf");
    }
}
