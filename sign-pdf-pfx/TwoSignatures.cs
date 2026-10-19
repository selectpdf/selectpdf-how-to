using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using SelectPdf.Universal;
using SelectPdf.Universal.Drawing;

static class TwoSignatures
{
    public static void Run()
    {
        // a second test certificate, for the customer
        using (RSA key = RSA.Create(2048))
        {
            var request = new CertificateRequest("CN=John Smith, O=Customer Inc", key,
                HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            using X509Certificate2 certificate = request.CreateSelfSigned(
                DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(1));
            File.WriteAllBytes("customer.pfx", certificate.Export(X509ContentType.Pfx, "customer-password"));
        }

        // the customer countersigns the copy Jane Doe already signed;
        // a new field name keeps the first signature intact
        PdfSecurityManager manager = new PdfSecurityManager();
        manager.Load("contract-signed.pdf");
        manager.Sign("customer.pfx", "customer-password", "Signature2",
            "Accepted", "New York", "",
            0, new RectangleF(320, 125, 260, 70));
        manager.Save("contract-countersigned.pdf");
        manager.Close();
    }
}
