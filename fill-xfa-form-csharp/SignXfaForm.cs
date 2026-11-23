using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using SelectPdf.Universal;

static class SignXfaForm
{
    public static void Run()
    {
        // a self-signed test certificate; in production, use the .pfx your certificate authority issued
        using (RSA key = RSA.Create(2048))
        {
            var request = new CertificateRequest("CN=Jane Doe, O=Example Ltd", key,
                HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            using X509Certificate2 certificate = request.CreateSelfSigned(
                DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(1));
            File.WriteAllBytes("signer.pfx", certificate.Export(X509ContentType.Pfx, "pfx-password"));
        }

        // fill the form and keep it as an XFA form
        PdfFormManager form = new PdfFormManager();
        form.Load("xfa-form.pdf");
        ((PdfFormFieldTextBox)form.Fields["Name"]).Text = "Jane Doe";
        ((PdfFormFieldTextBox)form.Fields["Quantity"]).Text = "3";
        ((PdfFormFieldCheckBox)form.Fields["Agree"]).Checked = true;
        byte[] filled = form.Save();
        form.Close();

        // sign the form's own signature field, named by its path or its own name
        PdfSecurityManager security = new PdfSecurityManager();
        security.Load(filled);
        security.Sign("signer.pfx", "pfx-password", "Signature",
            "Order approved", "London", "");
        security.Save("xfa-form-signed.pdf");
        security.Close();
    }
}
