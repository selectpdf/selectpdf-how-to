using System.Text;
using SelectPdf.Universal;

static class TamperedCopy
{
    public static void Run()
    {
        // change bytes the signature covers: the location recorded with it
        byte[] bytes = File.ReadAllBytes("contract-signed.pdf");
        byte[] from = Encoding.ASCII.GetBytes("(London)");
        byte[] to = Encoding.ASCII.GetBytes("(Paris!)");
        int at = bytes.AsSpan().IndexOf(from);
        to.CopyTo(bytes, at);
        File.WriteAllBytes("contract-tampered.pdf", bytes);

        PdfSecurityManager manager = new PdfSecurityManager();
        manager.Load("contract-tampered.pdf");
        using PdfDigitalCertificatesCollection roots =
            PdfDigitalCertificatesStore.GetCertificates("example-ca.pfx", "ca-password");
        foreach (PdfSignatureValidationResult result in manager.ValidateSignatures(roots))
        {
            Console.WriteLine($"{result.SignatureName}: {result.Status}, intact: {result.IsValid}");
            foreach (string message in result.Messages)
                Console.WriteLine("  " + message);
        }
        manager.Close();
    }
}
