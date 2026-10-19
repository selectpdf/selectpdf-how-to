using SelectPdf.Universal;
using SelectPdf.Universal.Drawing;

static class Countersigned
{
    public static void Run()
    {
        PdfSecurityManager signing = new PdfSecurityManager();
        signing.Load("contract-signed.pdf");
        signing.Sign("signer.pfx", "pfx-password", "Signature2", "Reviewed", "London", "",
            0, new RectangleF(320, 60, 260, 70));
        signing.Save("contract-countersigned.pdf");
        signing.Close();

        PdfSecurityManager manager = new PdfSecurityManager();
        manager.Load("contract-countersigned.pdf");
        using PdfDigitalCertificatesCollection roots =
            PdfDigitalCertificatesStore.GetCertificates("example-ca.pfx", "ca-password");
        foreach (PdfSignatureValidationResult result in manager.ValidateSignatures(roots))
        {
            Console.WriteLine($"{result.SignatureName}: {result.Status}, covers the whole document: {result.CoversWholeDocument}");
            foreach (string message in result.Messages)
                Console.WriteLine("  " + message);
        }
        manager.Close();
    }
}
