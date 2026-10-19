using System.Net;
using System.Text;
using SelectPdf.Universal;

// 1. The invoice data. In your application it comes from your database.
Invoice invoice = new Invoice("2026-118", new DateOnly(2026, 10, 17), "Fabrikam Ltd", "12 King Street, London",
[
    new InvoiceLine("Reporting service, October 2026", 1, 1200.00m),
    new InvoiceLine("Additional user licenses", 5, 40.00m),
    new InvoiceLine("Onboarding workshop", 1, 450.00m),
]);

// 2. The HTML template: plain HTML and CSS, with {{placeholders}} for the data.
string template = """
    <html><head><style>
      body { font-family: sans-serif; color: #222; }
      .top { display: flex; justify-content: space-between; }
      table { width: 100%; border-collapse: collapse; margin-top: 30px; }
      th { background: #1d4ed8; color: #fff; text-align: left; padding: 8px; }
      td { border-bottom: 1px solid #ddd; padding: 8px; }
      .num { text-align: right; }
      .total td { font-weight: bold; border: none; }
    </style></head><body>
      <div class="top">
        <div><h1>Invoice {{number}}</h1><p>Date: {{date}}</p></div>
        <div><b>Example Ltd</b><br>1 Market Road, Leeds<br>VAT GB 123 4567 89</div>
      </div>
      <p><b>Bill to:</b><br>{{customer}}<br>{{address}}</p>
      <table>
        <thead><tr><th>Description</th><th class="num">Qty</th>
          <th class="num">Unit price</th><th class="num">Amount</th></tr></thead>
        <tbody>{{rows}}</tbody>
        <tr class="total"><td colspan="3" class="num">Total due (GBP)</td><td class="num">{{total}}</td></tr>
      </table>
      <p>Payment within 30 days to account 12345678, sort code 01-02-03.</p>
    </body></html>
    """;

// 3. Fill in the template, HTML-encoding every value, one table row per line.
StringBuilder rows = new StringBuilder();
foreach (InvoiceLine line in invoice.Lines)
    rows.Append($"""
        <tr><td>{WebUtility.HtmlEncode(line.Description)}</td><td class="num">{line.Quantity}</td>
        <td class="num">{line.UnitPrice:N2}</td><td class="num">{line.Amount:N2}</td></tr>
        """);
string html = template
    .Replace("{{number}}", WebUtility.HtmlEncode(invoice.Number))
    .Replace("{{date}}", invoice.Date.ToString("d MMMM yyyy"))
    .Replace("{{customer}}", WebUtility.HtmlEncode(invoice.Customer))
    .Replace("{{address}}", WebUtility.HtmlEncode(invoice.Address))
    .Replace("{{rows}}", rows.ToString())
    .Replace("{{total}}", invoice.Total.ToString("N2"));

// 4. Convert to an A4 PDF with margins and a document title, and save it.
HtmlToPdf converter = new HtmlToPdf();
converter.Options.PdfPageSize = PdfPageSize.A4;
converter.Options.MarginTop = 30;
converter.Options.MarginBottom = 30;
converter.Options.MarginLeft = 30;
converter.Options.MarginRight = 30;
converter.Options.PdfDocumentInformation.Title = $"Invoice {invoice.Number}";
PdfDocument doc = converter.ConvertHtmlString(html);
doc.Save($"invoice-{invoice.Number}.pdf");
doc.Close();

record InvoiceLine(string Description, int Quantity, decimal UnitPrice)
{
    public decimal Amount => Quantity * UnitPrice;
}

record Invoice(string Number, DateOnly Date, string Customer, string Address, InvoiceLine[] Lines)
{
    public decimal Total => Lines.Sum(line => line.Amount);
}
