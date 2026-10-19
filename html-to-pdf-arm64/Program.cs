using System.Runtime.InteropServices;
using SelectPdf.Universal;

// 1. Where the program runs: Arm64 on AWS Graviton and other ARM64 Linux hosts.
Console.WriteLine($"{RuntimeInformation.OSDescription}, {RuntimeInformation.ProcessArchitecture}");

// 2. The same code as on x64: only the engine package differs.
string html = """
    <html>
      <body style="font-family: sans-serif">
        <h1>Shipping label #58213</h1>
        <p>Deliver to: Fabrikam Ltd, 12 King Street, London</p>
        <p>Rendered by SelectPdf.Universal on Linux.</p>
      </body>
    </html>
    """;

HtmlToPdf converter = new HtmlToPdf();
PdfDocument doc = converter.ConvertHtmlString(html);
doc.Save("label.pdf");
doc.Close();
