using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using SelectPdf.Universal;
using SelectPdf.Universal.Drawing;

// 1. Test certificates: a certificate authority (CA) and a signer certificate it issued.
// In production the signer's certificate comes from your CA or a public one.
DateTimeOffset now = DateTimeOffset.UtcNow;
using RSA caKey = RSA.Create(2048);
var caRequest = new CertificateRequest("CN=Example Test CA", caKey,
    HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
caRequest.CertificateExtensions.Add(new X509BasicConstraintsExtension(true, false, 0, true));
using X509Certificate2 ca = caRequest.CreateSelfSigned(now.AddDays(-1), now.AddYears(5));

using RSA signerKey = RSA.Create(2048);
var signerRequest = new CertificateRequest("CN=Jane Doe, O=Example Ltd", signerKey,
    HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
using X509Certificate2 issued = signerRequest.Create(ca, now.AddDays(-1), now.AddYears(1), [1, 2, 3, 4]);
using X509Certificate2 signer = issued.CopyWithPrivateKey(signerKey);
File.WriteAllBytes("signer.pfx", signer.Export(X509ContentType.Pfx, "pfx-password"));
// the CA certificate alone, without its private key: the root to trust
using X509Certificate2 caCertificate = X509CertificateLoader.LoadCertificate(ca.RawData);
File.WriteAllBytes("example-ca.pfx", caCertificate.Export(X509ContentType.Pfx, "ca-password"));

// 2. A signed PDF to check.
HtmlToPdf converter = new HtmlToPdf();
PdfDocument contract = converter.ConvertHtmlString("<h1>Service agreement</h1><p>Approved by:</p>");
contract.Save("contract.pdf");
contract.Close();
PdfSecurityManager signing = new PdfSecurityManager();
signing.Load("contract.pdf");
signing.Sign("signer.pfx", "pfx-password", "Signature1", "Approved", "London", "",
    0, new RectangleF(40, 60, 260, 70));
signing.Save("contract-signed.pdf");
signing.Close();

// 3. Load the signed PDF and validate every signature, trusting the CA as a root.
PdfSecurityManager manager = new PdfSecurityManager();
manager.Load("contract-signed.pdf");
using PdfDigitalCertificatesCollection roots =
    PdfDigitalCertificatesStore.GetCertificates("example-ca.pfx", "ca-password");
foreach (PdfSignatureValidationResult result in manager.ValidateSignatures(roots))
{
    Console.WriteLine($"{result.SignatureName}: {result.Status}");
    Console.WriteLine($"  signed by {result.SignerName} on {result.SigningTime}");
    Console.WriteLine($"  intact: {result.IsValid}, trusted: {result.IsTrusted}, " +
        $"covers the whole document: {result.CoversWholeDocument}");
    foreach (string message in result.Messages)
        Console.WriteLine("  " + message);
}
manager.Close();
