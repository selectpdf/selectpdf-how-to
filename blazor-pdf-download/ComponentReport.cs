using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.HtmlRendering;
using PdfSample;   // Report.razor
using SelectPdf.Universal;

static class ComponentReport
{
    // in Program.cs:
    // app.MapGet("/report.pdf", async (IServiceProvider services, ILoggerFactory logs, string customer) =>
    //     Results.File(await ComponentReport.CreatePdfAsync(services, logs, customer), "application/pdf", "report.pdf"));
    public static async Task<byte[]> CreatePdfAsync(IServiceProvider services, ILoggerFactory logs, string customer)
    {
        // render the Report.razor component to an HTML string
        await using var renderer = new HtmlRenderer(services, logs);
        string html = await renderer.Dispatcher.InvokeAsync(async () =>
        {
            var parameters = ParameterView.FromDictionary(new Dictionary<string, object?>
            {
                ["Customer"] = customer,
                ["Rows"] = new List<Report.ReportRow> { new("August", 128), new("September", 143) },
            });
            HtmlRootComponent output = await renderer.RenderComponentAsync<Report>(parameters);
            return output.ToHtmlString();
        });

        // then convert it like any other HTML string
        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument doc = await converter.ConvertHtmlStringAsync(html);
        byte[] pdf = doc.Save();
        doc.Close();
        return pdf;
    }

    public static async Task Run()
    {
        var services = new ServiceCollection().AddLogging().BuildServiceProvider();
        byte[] pdf = await CreatePdfAsync(services, services.GetRequiredService<ILoggerFactory>(), "Contoso Ltd");
        File.WriteAllBytes("report-component.pdf", pdf);
    }
}
