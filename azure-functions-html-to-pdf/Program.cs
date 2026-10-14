using System.Net;
using System.Web;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Hosting;
using SelectPdf.Universal;

new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .Build()
    .Run();

public static class InvoiceFunction
{
    // GET /api/Invoice?number=1042 returns the invoice as a PDF
    [Function("Invoice")]
    public static async Task<HttpResponseData> Invoice(
        [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
    {
        string number = HttpUtility.ParseQueryString(req.Url.Query)["number"] ?? "1";
        string html = $"""
            <h1>Invoice #{HttpUtility.HtmlEncode(number)}</h1>
            <p>Billed to Contoso Ltd.</p>
            """;

        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument doc = await converter.ConvertHtmlStringAsync(html);
        byte[] pdf = doc.Save();
        doc.Close();

        HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/pdf");
        await response.Body.WriteAsync(pdf);
        return response;
    }
}
