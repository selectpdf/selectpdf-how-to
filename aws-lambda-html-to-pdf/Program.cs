using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using SelectPdf.Universal;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace PdfLambda;

public class Function
{
    // a function URL or HTTP API request: the HTML in the body comes back as a PDF
    public async Task<APIGatewayHttpApiV2ProxyResponse> Handler(
        APIGatewayHttpApiV2ProxyRequest request, ILambdaContext context)
    {
        string html = request.IsBase64Encoded
            ? System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(request.Body))
            : request.Body ?? "<h1>Hello from AWS Lambda</h1>";

        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.DenyLocalFileAccess = true;   // the HTML comes from the caller
        PdfDocument doc = await converter.ConvertHtmlStringAsync(html);
        byte[] pdf = doc.Save();
        doc.Close();

        // Lambda responses are JSON: the PDF travels base64-encoded (about 4.4 MB of PDF fits in 6 MB)
        return new APIGatewayHttpApiV2ProxyResponse
        {
            StatusCode = 200,
            Headers = new Dictionary<string, string> { ["Content-Type"] = "application/pdf" },
            Body = Convert.ToBase64String(pdf),
            IsBase64Encoded = true,
        };
    }
}
