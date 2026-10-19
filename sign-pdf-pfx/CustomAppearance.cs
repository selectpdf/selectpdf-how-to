using SelectPdf.Universal;
using SelectPdf.Universal.Drawing;

static class CustomAppearance
{
    public static void Run()
    {
        // a round seal for the background; in your application, read your PNG file
        HtmlToImage sealMaker = new HtmlToImage(200, 200);
        byte[] seal = sealMaker.ConvertHtmlString("""
            <body style="margin:0">
              <div style="width:180px; height:180px; margin:10px; border:8px solid #1d4ed8;
                          border-radius:50%; box-sizing:border-box; display:flex; align-items:center;
                          justify-content:center; font:bold 28px sans-serif; color:#1d4ed8">EXAMPLE</div>
            </body>
            """);

        PdfSecurityManager manager = new PdfSecurityManager();
        manager.Load("contract.pdf");
        manager.SignatureBackgroundImage = seal;
        manager.SignatureBackgroundOpacity = 0.4f;
        manager.Sign("signer.pfx", "pfx-password", "Signature1",
            "Approved", "London", "",
            0, new RectangleF(40, 125, 260, 70));
        manager.Save("contract-logo-signed.pdf");
        manager.Close();
    }
}
