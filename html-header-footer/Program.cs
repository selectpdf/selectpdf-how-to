using SelectPdf.Universal;

HtmlToPdf converter = new HtmlToPdf();

// header: a logo and a title, written in HTML
converter.Options.DisplayHeader = true;
converter.Header.Height = 60;
string header = """
    <div style="display: flex; align-items: center; gap: 16px; padding: 16px 40px;
                border-bottom: 3px solid #c2410c; font-family: sans-serif">
      <svg width="48" height="48" font-family="sans-serif" font-weight="bold" font-size="24">
        <rect width="48" height="48" rx="10" fill="#c2410c"/>
        <text x="24" y="33" fill="white" text-anchor="middle">A</text></svg>
      <span style="font-size: 28px; font-weight: bold">Acme Ltd. Sales report</span>
    </div>
    """;
converter.Header.Add(new PdfHtmlSection(header, ""));

// footer: the date the report was generated
converter.Options.DisplayFooter = true;
converter.Footer.Height = 40;
string today = DateTime.Today.ToLongDateString();
converter.Footer.Add(new PdfHtmlSection(
    $"<div style='padding: 16px 40px; font: 20px sans-serif; color: #555'>Generated on {today}</div>", ""));

// a report long enough for several pages
string rows = string.Concat(Enumerable.Range(1, 150).Select(i =>
    $"<tr><td>Order {1000 + i}</td><td>{i * 7 % 90 + 10} units</td></tr>"));
PdfDocument doc = converter.ConvertHtmlString(
    $"<body style='margin: 0 40px; font-family: sans-serif'><h1>Orders</h1><table width='400'>{rows}</table></body>");
doc.Save("report.pdf");
doc.Close();
