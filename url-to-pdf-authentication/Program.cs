using SelectPdf.Universal;

// 1. A stand-in for your site: a report page that needs a bearer token.
// It runs on localhost so the sample works anywhere.
WebApplication app = WebApplication.Create();
app.Urls.Add("http://127.0.0.1:0"); // any free port
app.MapGet("/report", (HttpRequest request) =>
    request.Headers.Authorization == "Bearer s3cret-token"
        ? Results.Content("<h1>Sales report</h1><p>Signed in: the converter sent the token.</p>", "text/html")
        : Results.Content("<h1>Please sign in</h1>", "text/html", statusCode: 401));
await app.StartAsync();
string site = app.Urls.First();

// 2. Send the Authorization header with every request the converter makes.
HtmlToPdf converter = new HtmlToPdf();
converter.Options.HttpHeaders.Add("Authorization", "Bearer s3cret-token");

// 3. Convert the protected page and save it.
PdfDocument doc = converter.ConvertUrl($"{site}/report");
doc.Save("report.pdf");
doc.Close();

await app.StopAsync();
