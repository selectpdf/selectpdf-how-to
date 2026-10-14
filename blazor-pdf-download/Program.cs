using System.Net;
using PdfSample;   // App.razor
using SelectPdf.Universal;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
var app = builder.Build();

app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

// GET /report.pdf?customer=... : the Download PDF link on the Blazor page points here
app.MapGet("/report.pdf", async (string? customer, CancellationToken cancel) =>
{
    string name = WebUtility.HtmlEncode(customer ?? "Guest");
    string html = $$"""
        <style>body { font-family: sans-serif; margin: 40px; }</style>
        <h1>Monthly report</h1>
        <p>Prepared for <b>{{name}}</b> on {{DateTime.UtcNow:yyyy-MM-dd}}.</p>
        <table border="1" cellpadding="6" style="border-collapse:collapse">
          <tr><th>Month</th><th>Orders</th></tr>
          <tr><td>August</td><td>128</td></tr>
          <tr><td>September</td><td>143</td></tr>
        </table>
        """;

    HtmlToPdf converter = new HtmlToPdf();          // one converter per request
    converter.Options.PdfPageSize = PdfPageSize.A4;
    converter.Options.DenyLocalFileAccess = true;   // no file:// access from the HTML

    PdfDocument doc = await converter.ConvertHtmlStringAsync(html, cancel);
    byte[] pdf = doc.Save();
    doc.Close();

    return Results.File(pdf, "application/pdf", "report.pdf");
});

app.Run();
