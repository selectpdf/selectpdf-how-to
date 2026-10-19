using System.Text;
using SelectPdf.Universal;

static class BasicAuth
{
    public static async Task Run()
    {
        // a page behind HTTP Basic authentication
        string expected = "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes("reports:pa55word"));
        WebApplication app = WebApplication.Create();
        app.Urls.Add("http://127.0.0.1:0");
        app.MapGet("/status", (HttpRequest request, HttpResponse response) =>
        {
            if (request.Headers.Authorization == expected)
                return Results.Content("<h1>System status</h1><p>Signed in with HTTP authentication.</p>", "text/html");
            response.Headers.WWWAuthenticate = "Basic realm=\"reports\"";
            return Results.Unauthorized();
        });
        await app.StartAsync();

        // the converter answers the login challenge with these credentials
        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.Authentication.Username = "reports";
        converter.Options.Authentication.Password = "pa55word";
        PdfDocument doc = converter.ConvertUrl($"{app.Urls.First()}/status");
        doc.Save("status.pdf");
        doc.Close();

        await app.StopAsync();
    }
}
