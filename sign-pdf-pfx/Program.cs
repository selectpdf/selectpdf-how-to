using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using SelectPdf.Universal;
using SelectPdf.Universal.Drawing;

// 1. A self-signed test certificate, saved as signer.pfx.
// In production, use the .pfx file your certificate authority issued.
using (RSA key = RSA.Create(2048))
{
    var request = new CertificateRequest("CN=Jane Doe, O=Example Ltd", key,
        HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
    using X509Certificate2 certificate = request.CreateSelfSigned(
        DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(1));
    File.WriteAllBytes("signer.pfx", certificate.Export(X509ContentType.Pfx, "pfx-password"));
}

// 2. The PDF to sign: a one-page contract made from HTML.
HtmlToPdf converter = new HtmlToPdf();
PdfDocument contract = converter.ConvertHtmlString("""
    <h1>Service agreement</h1>
    <p>Example Ltd provides the reporting service described below to the customer
    from 1 November 2026, for twelve months.</p>
    <p>Fees are invoiced monthly and due within 30 days.</p>
    <p style="margin-top:60px">Approved by:</p>
    """);
contract.Save("contract.pdf");
contract.Close();

// 3. Load the PDF and sign it with the certificate, adding
// a visible signature on the first page.
PdfSecurityManager manager = new PdfSecurityManager();
manager.Load("contract.pdf");
manager.Sign("signer.pfx", "pfx-password", "Signature1",
    "Approved", "London", "jane.doe@example.com",
    0, new RectangleF(40, 125, 260, 70));

// 4. Save the signed copy. Close releases the document and the certificate.
manager.Save("contract-signed.pdf");
manager.Close();
