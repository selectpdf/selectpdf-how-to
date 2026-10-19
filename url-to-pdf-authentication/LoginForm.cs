using SelectPdf.Universal;

static class LoginForm
{
    public static async Task Run()
    {
        // a site with its own login form; the dashboard needs the cookie it sets
        WebApplication app = WebApplication.Create();
        app.Urls.Add("http://127.0.0.1:0");
        app.MapGet("/login", () => Results.Content("""
            <form method="post" action="/login">
              <input id="user" name="user"> <input id="pass" name="pass" type="password">
              <button id="sign-in" type="submit">Sign in</button>
            </form>
            """, "text/html"));
        app.MapPost("/login", (HttpContext context) =>
        {
            IFormCollection form = context.Request.Form;
            if (form["user"] != "anna" || form["pass"] != "pa55word") return Results.Redirect("/login");
            context.Response.Cookies.Append("session", "anna-session");
            return Results.Redirect("/dashboard");
        });
        app.MapGet("/dashboard", (HttpRequest request) =>
            request.Cookies["session"] == "anna-session"
                ? Results.Content("<h1>Dashboard</h1><p>Signed in through the login form.</p>", "text/html")
                : Results.Redirect("/login"));
        await app.StartAsync();
        string site = app.Urls.First();

        // the converter opens the login page, fills in the form and submits it first
        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.LoginOptions.LoginPage = $"{site}/login";
        converter.Options.LoginOptions.UsernameFieldSelector = "#user";
        converter.Options.LoginOptions.PasswordFieldSelector = "#pass";
        converter.Options.LoginOptions.SubmitButtonSelector = "#sign-in";
        converter.Options.LoginOptions.Username = "anna";
        converter.Options.LoginOptions.Password = "pa55word";
        PdfDocument doc = converter.ConvertUrl($"{site}/dashboard");
        doc.Save("dashboard.pdf");
        doc.Close();

        await app.StopAsync();
    }
}
