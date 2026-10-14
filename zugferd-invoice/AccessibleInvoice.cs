using System.Text;
using SelectPdf.Universal;

static class AccessibleInvoice
{
    public static void Run()
    {
        string html = """
            <html lang="en">
            <head><title>Invoice 2026-003</title></head>
            <body>
              <h1>Invoice 2026-003</h1>
              <p>Contoso GmbH to Fabrikam GmbH. Net 200.00 EUR, VAT 19% 38.00 EUR, total due 238.00 EUR.</p>
            </body>
            </html>
            """;

        // BASIC WL: header and totals, without invoice lines
        string xml = """
            <?xml version="1.0" encoding="UTF-8"?>
            <rsm:CrossIndustryInvoice xmlns:rsm="urn:un:unece:uncefact:data:standard:CrossIndustryInvoice:100" xmlns:ram="urn:un:unece:uncefact:data:standard:ReusableAggregateBusinessInformationEntity:100" xmlns:udt="urn:un:unece:uncefact:data:standard:UnqualifiedDataType:100">
              <rsm:ExchangedDocumentContext><ram:GuidelineSpecifiedDocumentContextParameter><ram:ID>urn:factur-x.eu:1p0:basicwl</ram:ID></ram:GuidelineSpecifiedDocumentContextParameter></rsm:ExchangedDocumentContext>
              <rsm:ExchangedDocument><ram:ID>2026-003</ram:ID><ram:TypeCode>380</ram:TypeCode><ram:IssueDateTime><udt:DateTimeString format="102">20261013</udt:DateTimeString></ram:IssueDateTime></rsm:ExchangedDocument>
              <rsm:SupplyChainTradeTransaction>
                <ram:ApplicableHeaderTradeAgreement>
                  <ram:SellerTradeParty><ram:Name>Contoso GmbH</ram:Name><ram:PostalTradeAddress><ram:CityName>Berlin</ram:CityName><ram:CountryID>DE</ram:CountryID></ram:PostalTradeAddress><ram:SpecifiedTaxRegistration><ram:ID schemeID="VA">DE123456789</ram:ID></ram:SpecifiedTaxRegistration></ram:SellerTradeParty>
                  <ram:BuyerTradeParty><ram:Name>Fabrikam GmbH</ram:Name><ram:PostalTradeAddress><ram:CityName>Munich</ram:CityName><ram:CountryID>DE</ram:CountryID></ram:PostalTradeAddress></ram:BuyerTradeParty>
                </ram:ApplicableHeaderTradeAgreement>
                <ram:ApplicableHeaderTradeDelivery/>
                <ram:ApplicableHeaderTradeSettlement>
                  <ram:InvoiceCurrencyCode>EUR</ram:InvoiceCurrencyCode>
                  <ram:ApplicableTradeTax><ram:CalculatedAmount>38.00</ram:CalculatedAmount><ram:TypeCode>VAT</ram:TypeCode><ram:BasisAmount>200.00</ram:BasisAmount><ram:CategoryCode>S</ram:CategoryCode><ram:RateApplicablePercent>19</ram:RateApplicablePercent></ram:ApplicableTradeTax>
                  <ram:SpecifiedTradeSettlementHeaderMonetarySummation><ram:LineTotalAmount>200.00</ram:LineTotalAmount><ram:TaxBasisTotalAmount>200.00</ram:TaxBasisTotalAmount><ram:TaxTotalAmount currencyID="EUR">38.00</ram:TaxTotalAmount><ram:GrandTotalAmount>238.00</ram:GrandTotalAmount><ram:DuePayableAmount>238.00</ram:DuePayableAmount></ram:SpecifiedTradeSettlementHeaderMonetarySummation>
                </ram:ApplicableHeaderTradeSettlement>
              </rsm:SupplyChainTradeTransaction>
            </rsm:CrossIndustryInvoice>
            """;

        HtmlToPdf converter = new HtmlToPdf();

        // PDF/A-3A with PDF/UA-1: the visible invoice is also accessible
        converter.Options.PdfStandard = PdfStandard.PdfA3A;
        converter.Options.AccessibilityStandard = PdfUAStandard.UA1;
        converter.Options.Title = "Invoice 2026-003";
        converter.Options.Language = "en-US";

        PdfDocument doc = converter.ConvertHtmlString(html);

        // BASIC WL has no lines, so the page carries more than the XML (Data)
        using (MemoryStream invoiceXml = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
        {
            doc.AddZugferdInvoice(invoiceXml, ZugferdProfile.BasicWL,
                PdfAttachmentRelationship.Data);
        }

        doc.Save("invoice-2026-003-pdfa3a.pdf");
        doc.Close();
    }
}
