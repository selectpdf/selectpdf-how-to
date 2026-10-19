using SelectPdf.Universal;

var builder = WebApplication.CreateBuilder(args);

// on Cloud Run, listen on the port it passes in PORT (8080 by default)
string? port = Environment.GetEnvironmentVariable("PORT");
if (port != null) builder.WebHost.UseUrls($"http://0.0.0.0:{port}");
var app = builder.Build();

// GET /report.pdf: a PDF made on the server, with text in several scripts
app.MapGet("/report.pdf", async (CancellationToken cancel) =>
{
    string html = """
        <h1>Monthly report</h1>
        <p>English · Deutsch · Ελληνικά · Русский</p>
        <p>日本語 · 中文 · 한국어 · العربية</p>
        """;

    HtmlToPdf converter = new HtmlToPdf();
    PdfDocument doc = await converter.ConvertHtmlStringAsync(html, cancel);
    byte[] pdf = doc.Save();
    doc.Close();

    return Results.File(pdf, "application/pdf");
});

app.Run();
