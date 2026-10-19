using SelectPdf.Universal;

// 1. One page, many scripts. Arial and Times New Roman are not on a Linux server:
// the library's Liberation fonts stand in for them with the same measurements,
// and the SelectPdf.Universal.Fonts package (in the .csproj) covers the other scripts.
string html = """
    <html><body style="font-family: Arial, sans-serif; font-size: 18px">
      <h1>Invoice total</h1>
      <table cellpadding="6">
        <tr><td>English</td><td>Invoice total</td></tr>
        <tr><td>Greek</td><td>Σύνολο τιμολογίου</td></tr>
        <tr><td>Russian</td><td>Итого по счёту</td></tr>
        <tr><td>Arabic</td><td dir="rtl">إجمالي الفاتورة</td></tr>
        <tr><td>Hindi</td><td>चालान का कुल योग</td></tr>
        <tr><td>Thai</td><td>ยอดรวมใบแจ้งหนี้</td></tr>
        <tr><td>Chinese</td><td>发票总额</td></tr>
        <tr><td>Japanese</td><td>請求書の合計</td></tr>
        <tr><td>Korean</td><td>청구서 합계</td></tr>
      </table>
      <p style="font-family: 'Times New Roman', serif">Times New Roman text keeps its width
      on every server, so lines break in the same places.</p>
    </body></html>
    """;

// 2. Convert and save. Nothing in the code changes between Windows and Linux.
HtmlToPdf converter = new HtmlToPdf();
PdfDocument doc = converter.ConvertHtmlString(html);
doc.Save("languages.pdf");
doc.Close();
