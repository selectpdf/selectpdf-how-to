using SelectPdf.Universal;

static class StreamDownload
{
    // DownloadButton.razor calls this and streams the result to the browser
    public static async Task<Stream> CreatePdfAsync(string customer, CancellationToken cancel = default)
    {
        string html = $"<h1>Monthly report</h1><p>Prepared for {System.Net.WebUtility.HtmlEncode(customer)}</p>";

        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument doc = await converter.ConvertHtmlStringAsync(html, cancel);
        var stream = new MemoryStream();
        doc.Save(stream);
        doc.Close();
        stream.Position = 0;
        return stream;
    }

    public static async Task Run()
    {
        await using Stream pdf = await CreatePdfAsync("Contoso Ltd");
        await using FileStream file = File.Create("report-stream.pdf");
        await pdf.CopyToAsync(file);
    }
}
