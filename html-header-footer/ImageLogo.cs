using SelectPdf.Universal;

static class ImageLogo
{
    public static void Run()
    {
        // a PNG logo; in your application read it from a file or an embedded resource
        byte[] logo = Convert.FromBase64String(
            "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAIAAAD8GO2jAAAAKklEQVR42mM45MhDU8QwasGoBaMWjFowasGoBaMWjFowasGoBaMWDBULACVwPD2wuxyUAAAAAElFTkSuQmCC");

        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.DisplayHeader = true;
        converter.Header.Height = 50;

        // image section: 30 points wide, height kept in proportion
        converter.Header.Add(new PdfImageSection(20, 10, 30, new MemoryStream(logo)));

        // text section next to it
        PdfTextSection title = new PdfTextSection(60, 18, "Acme Ltd. Sales report",
            PdfFont.CreateFromSystemFont("Liberation Sans", 14f));
        converter.Header.Add(title);

        string rows = string.Concat(Enumerable.Range(1, 120).Select(i => $"<p>Line item {i}</p>"));
        PdfDocument doc = converter.ConvertHtmlString($"<h1>Report</h1>{rows}");
        doc.Save("image-logo.pdf");
        doc.Close();
    }
}
