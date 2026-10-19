using SelectPdf.Universal;

static class CookieAuth
{
    public static async Task Run()
    {
        // a page that needs the session cookie of a signed-in user
        WebApplication app = WebApplication.Create();
        app.Urls.Add("http://127.0.0.1:0");
        app.MapGet("/orders", (HttpRequest request) =>
            request.Cookies["session"] == "user-42-session"
                ? Results.Content("<h1>My orders</h1><p>Signed in with the session cookie.</p>", "text/html")
                : Results.Redirect("/login"));
        await app.StartAsync();

        // in a web app, read the cookie from the current request:
        // Request.Cookies[".AspNetCore.Cookies"]
        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.HttpCookies.Add("session", "user-42-session");
        PdfDocument doc = converter.ConvertUrl($"{app.Urls.First()}/orders");
        doc.Save("orders.pdf");
        doc.Close();

        await app.StopAsync();
    }
}
