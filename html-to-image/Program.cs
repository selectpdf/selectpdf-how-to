using SelectPdf.Universal;

// 1. a web page, by URL, in a 1280 x 800 px browser window
HtmlToImage converter = new HtmlToImage(1280, 800);

// the image is returned as a byte array, PNG by default
byte[] page = converter.ConvertUrl("https://selectpdf.com");
File.WriteAllBytes("webpage.png", page);

// 2. an HTML string, rendered as a 1200 x 630 px social card;
// the base URL resolves the relative image path
string html = """
    <body style="margin:0; font-family:sans-serif; background:#fff7ed">
      <div style="padding:80px">
        <img src="img/selectpdf-logo-h128.png" alt="SelectPdf" height="64">
        <h1 style="font-size:64px">Release notes, October 2026</h1>
        <p style="font-size:32px">What changed in the reporting module.</p>
      </div>
    </body>
    """;
HtmlToImage cardConverter = new HtmlToImage(1200, 630);
byte[] card = cardConverter.ConvertHtmlString(html, "https://selectpdf.com/");
File.WriteAllBytes("card.png", card);
