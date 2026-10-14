using SelectPdf.Universal;

static class ConvertAsync
{
    public static async Task Run()
    {
        // in a web app or service: await the conversion, and give up after 30 seconds
        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(30));

        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument doc = await converter.ConvertUrlAsync("https://selectpdf.com", timeout.Token);

        byte[] pdf = doc.Save();   // the PDF as bytes, for a response or a database
        doc.Close();

        await File.WriteAllBytesAsync("webpage-async.pdf", pdf);
    }
}
