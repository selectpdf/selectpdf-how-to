using SelectPdf.Universal;

// at most 4 pages render at the same time; the rest wait their turn in order
// (set it before the first conversion; the default is 8)
HtmlToPdfOptions.MaximumConcurrentConversions = 4;

string[] urls =
[
    "https://selectpdf.com",
    "https://selectpdf.com/pricing/",
    "https://selectpdf.com/pdf-library-cross-platform/",
    "https://selectpdf.com/html-to-pdf-api/",
    "https://selectpdf.com/community-edition/",
    "https://selectpdf.com/downloads/",
];

// a time limit for the whole batch
using var timeout = new CancellationTokenSource(TimeSpan.FromMinutes(2));

// start every conversion, then wait for all of them: one converter per conversion
PdfDocument[] docs = await Task.WhenAll(urls.Select(url =>
{
    HtmlToPdf converter = new HtmlToPdf();
    return converter.ConvertUrlAsync(url, timeout.Token);
}));

// the documents come back in the order of the URLs
for (int i = 0; i < docs.Length; i++)
{
    docs[i].Save($"page-{i + 1}.pdf");
    docs[i].Close();
}
