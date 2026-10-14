using SelectPdf.Universal;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// GET /report.pdf: a PDF made on the server, with text in Latin, Greek and CJK scripts
app.MapGet("/report.pdf", async (CancellationToken cancel) =>
{
    string html = """
        <h1>Quarterly report</h1>
        <p>English · Deutsch · Ελληνικά</p>
        <p>日本語 · 中文 · 한국어</p>
        """;

    HtmlToPdf converter = new HtmlToPdf();
    PdfDocument doc = await converter.ConvertHtmlStringAsync(html, cancel);
    byte[] pdf = doc.Save();
    doc.Close();

    return Results.File(pdf, "application/pdf");
});

app.Run();
