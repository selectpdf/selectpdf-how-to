# Convert a page behind a login to PDF in C#

Convert a password-protected web page to PDF in C# with SelectPdf.Universal: send a bearer token or session cookie, answer Basic auth, or fill in a login form.

**Step-by-step guide:** https://selectpdf.com/how-to/url-to-pdf-authentication/  
**Video walkthrough:** https://www.youtube.com/watch?v=RafvzqtTGoY  
**Short version:** https://www.youtube.com/shorts/0iPQ-PZD1sc

## Run it

```bash
dotnet run
```

The request returns `report.pdf`. Requires the .NET 10 SDK.

## Variations

Each variation is a file next to Program.cs; the `variations` project runs them. Run `dotnet run` once first: some reuse the files Program.cs writes.

| Run | What it shows |
|---|---|
| `dotnet run --project variations -- CookieAuth` | Send the session cookie of a signed-in user ([CookieAuth.cs](CookieAuth.cs)) |
| `dotnet run --project variations -- BasicAuth` | HTTP Basic authentication ([BasicAuth.cs](BasicAuth.cs)) |
| `dotnet run --project variations -- LoginForm` | Sign in through the site's login form ([LoginForm.cs](LoginForm.cs)) |

## License key

Without a key, every page carries a trial watermark. Set `SELECTPDF_LICENSE_KEY` to your key, or assign `SelectPdf.Universal.GlobalProperties.LicenseKey` before the first conversion. [Free trial](https://selectpdf.com/downloads/) · [Pricing](https://selectpdf.com/pricing/)

## Documentation

- [Web page authentication](https://selectpdf.com/pdf-library/html/WebPageAuthentication.htm)
- [HTTP headers](https://selectpdf.com/pdf-library/html/HTTPHeaders.htm)
- [HTTP cookies](https://selectpdf.com/pdf-library/html/HTTPCookies.htm)
- [Security recommendations](https://selectpdf.com/pdf-library/html/Security-Recommendations.htm)
