using SelectPdf.Universal;

static class RevocationCheck
{
    public static void Run()
    {
        // ask the certificate's issuer whether it was revoked (OCSP or CRL, over the network)
        PdfSecurityManager manager = new PdfSecurityManager();
        manager.Load("contract-signed.pdf");
        manager.RevocationCheckEnabled = true;
        using PdfDigitalCertificatesCollection roots =
            PdfDigitalCertificatesStore.GetCertificates("example-ca.pfx", "ca-password");
        foreach (PdfSignatureValidationResult result in manager.ValidateSignatures(roots))
        {
            Console.WriteLine($"{result.SignatureName}: {result.Status}, revocation: {result.RevocationStatus}");
            foreach (string message in result.Messages)
                Console.WriteLine("  " + message);
        }
        manager.Close();
    }
}
