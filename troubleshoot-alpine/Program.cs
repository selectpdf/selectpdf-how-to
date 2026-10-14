using System.Runtime.InteropServices;
using SelectPdf.Universal;

// linux-musl-x64 on Alpine, where the native engines cannot run
Console.WriteLine($".NET runtime: {RuntimeInformation.RuntimeIdentifier}");

// convert in the selectpdf/engine container; EngineEndpoint and EngineAccessToken
// start from the SELECTPDF_ENGINE_ENDPOINT and SELECTPDF_ENGINE_TOKEN variables
GlobalProperties.RenderingEngine = RenderingEngine.ChromiumRemote;
GlobalProperties.EngineTimeout = TimeSpan.FromSeconds(60);

string html = """
    <html>
      <body style="font-family: sans-serif">
        <h1>Shipping report</h1>
        <p>Converted to PDF by SelectPdf.Universal.</p>
      </body>
    </html>
    """;

HtmlToPdf converter = new HtmlToPdf();
PdfDocument doc = converter.ConvertHtmlString(html);
doc.Save("report.pdf");
doc.Close();
Console.WriteLine("report.pdf saved");
