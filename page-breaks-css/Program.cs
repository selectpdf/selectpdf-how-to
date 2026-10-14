using SelectPdf.Universal;

// a report: a cover page and one chapter per region
string chapters = "";
foreach (string region in new[] { "North", "South", "West" })
{
    chapters += $"""
        <section class="chapter">
          <h2>{region} region</h2>
          <p>Sales, returns and new customers for the {region} region.</p>
        </section>
        """;
}

// the page breaks come from the page's CSS
string html = $$"""
    <style>
      .cover { page-break-after: always; }
      .chapter { page-break-before: always; }
    </style>
    <div class="cover">
      <h1>Annual report 2026</h1>
      <p>Contoso Ltd</p>
    </div>
    {{chapters}}
    """;

HtmlToPdf converter = new HtmlToPdf();
PdfDocument doc = converter.ConvertHtmlString(html);
Console.WriteLine($"{doc.Pages.Count} pages");
doc.Save("report.pdf");
doc.Close();
