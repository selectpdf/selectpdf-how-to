using SelectPdf.Universal;
using SelectPdf.Universal.Drawing;

static class SignNewDocument
{
    public static void Run()
    {
        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument invoice = converter.ConvertHtmlString("""
            <h1>Invoice 2026-118</h1>
            <p>Reporting service, October 2026: 1,200.00 EUR</p>
            """);

        // the document is signed when it is saved, so keep the certificates until then
        using PdfDigitalCertificatesCollection certificates =
            PdfDigitalCertificatesStore.GetCertificates("signer.pfx", "pfx-password");
        PdfDigitalSignatureElement signature =
            new PdfDigitalSignatureElement(new RectangleF(40, 100, 260, 70), certificates[0]);
        signature.Reason = "Issued";
        signature.Location = "London";
        invoice.Pages[0].Add(signature);

        invoice.Save("invoice-signed.pdf");
        invoice.Close();
    }
}
