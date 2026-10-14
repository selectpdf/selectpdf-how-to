using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.HtmlRendering;
using PdfSample;   // Invoice.razor
using SelectPdf.Universal;

static class RazorInvoice
{
    public static async Task Run()
    {
        CultureInfo.CurrentCulture = new CultureInfo("en-US");

        // render the Invoice.razor component to an HTML string, no browser or HTTP request involved
        var services = new ServiceCollection().AddLogging().BuildServiceProvider();
        await using var renderer = new HtmlRenderer(services, services.GetRequiredService<ILoggerFactory>());

        string html = await renderer.Dispatcher.InvokeAsync(async () =>
        {
            var parameters = ParameterView.FromDictionary(new Dictionary<string, object?>
            {
                ["Number"] = 1042,
                ["Customer"] = "Contoso Ltd",
                ["Lines"] = new List<Invoice.InvoiceLine> { new("Consulting", 1200m), new("Support plan", 300m) },
            });
            HtmlRootComponent output = await renderer.RenderComponentAsync<Invoice>(parameters);
            return output.ToHtmlString();
        });

        // then convert it like any other HTML string
        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument doc = await converter.ConvertHtmlStringAsync(html);
        doc.Save("invoice-1042.pdf");
        doc.Close();
    }
}
