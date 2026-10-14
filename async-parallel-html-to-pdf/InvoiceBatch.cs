using SelectPdf.Universal;

static class InvoiceBatch
{
    public static async Task Run()
    {
        Directory.CreateDirectory("invoices");
        var invoices = Enumerable.Range(1001, 20);

        // a long batch: convert at most as many as there are processors at a time,
        // and save each PDF as soon as it is ready instead of holding them all in memory
        var options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };
        await Parallel.ForEachAsync(invoices, options, async (number, cancel) =>
        {
            string html = $"<h1>Invoice #{number}</h1><p>Billed to customer {number % 7 + 1}.</p>";

            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument doc = await converter.ConvertHtmlStringAsync(html, cancel);
            doc.Save(Path.Combine("invoices", $"invoice-{number}.pdf"));
            doc.Close();
        });
    }
}
