using SelectPdf.Universal;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// POST /pdf with {"html": "..."} returns the HTML rendered as a PDF download
app.MapPost("/pdf", async (PdfRequest request, CancellationToken cancel) =>
{
    HtmlToPdf converter = new HtmlToPdf();
    converter.Options.PdfPageSize = PdfPageSize.A4;
    converter.Options.DenyLocalFileAccess = true;   // the HTML comes from the caller: no file:// access

    PdfDocument doc = await converter.ConvertHtmlStringAsync(request.Html, cancel);
    byte[] pdf = doc.Save();
    doc.Close();

    return Results.File(pdf, "application/pdf", "document.pdf");
});

app.Run();

record PdfRequest(string Html);
