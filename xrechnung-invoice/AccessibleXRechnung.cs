using System.Text;
using SelectPdf.Universal;

static class AccessibleXRechnung
{
    public static void Run()
    {
        string xml = """
            <?xml version="1.0" encoding="UTF-8"?>
            <rsm:CrossIndustryInvoice xmlns:rsm="urn:un:unece:uncefact:data:standard:CrossIndustryInvoice:100"
              xmlns:ram="urn:un:unece:uncefact:data:standard:ReusableAggregateBusinessInformationEntity:100"
              xmlns:udt="urn:un:unece:uncefact:data:standard:UnqualifiedDataType:100">
              <rsm:ExchangedDocumentContext><ram:GuidelineSpecifiedDocumentContextParameter>
                <ram:ID>urn:cen.eu:en16931:2017#compliant#urn:xeinkauf.de:kosit:xrechnung_3.0</ram:ID>
              </ram:GuidelineSpecifiedDocumentContextParameter></rsm:ExchangedDocumentContext>
              <rsm:ExchangedDocument>
                <ram:ID>RE-2026-0816</ram:ID><ram:TypeCode>380</ram:TypeCode>
                <ram:IssueDateTime><udt:DateTimeString format="102">20261013</udt:DateTimeString></ram:IssueDateTime>
              </rsm:ExchangedDocument>
              <rsm:SupplyChainTradeTransaction>
                <ram:IncludedSupplyChainTradeLineItem>
                  <ram:AssociatedDocumentLineDocument><ram:LineID>1</ram:LineID></ram:AssociatedDocumentLineDocument>
                  <ram:SpecifiedTradeProduct><ram:Name>Hosting, October 2026</ram:Name></ram:SpecifiedTradeProduct>
                  <ram:SpecifiedLineTradeSettlement><ram:SpecifiedTradeSettlementLineMonetarySummation>
                    <ram:LineTotalAmount>500.00</ram:LineTotalAmount>
                  </ram:SpecifiedTradeSettlementLineMonetarySummation></ram:SpecifiedLineTradeSettlement>
                </ram:IncludedSupplyChainTradeLineItem>
                <ram:ApplicableHeaderTradeAgreement>
                  <ram:BuyerReference>04011000-12345-34</ram:BuyerReference>
                  <ram:SellerTradeParty><ram:Name>Contoso GmbH</ram:Name></ram:SellerTradeParty>
                  <ram:BuyerTradeParty><ram:Name>Stadt Musterstadt</ram:Name></ram:BuyerTradeParty>
                </ram:ApplicableHeaderTradeAgreement>
                <ram:ApplicableHeaderTradeDelivery/>
                <ram:ApplicableHeaderTradeSettlement>
                  <ram:InvoiceCurrencyCode>EUR</ram:InvoiceCurrencyCode>
                  <ram:SpecifiedTradeSettlementHeaderMonetarySummation>
                    <ram:TaxBasisTotalAmount>500.00</ram:TaxBasisTotalAmount>
                    <ram:TaxTotalAmount currencyID="EUR">95.00</ram:TaxTotalAmount>
                    <ram:GrandTotalAmount>595.00</ram:GrandTotalAmount>
                    <ram:DuePayableAmount>595.00</ram:DuePayableAmount>
                  </ram:SpecifiedTradeSettlementHeaderMonetarySummation>
                </ram:ApplicableHeaderTradeSettlement>
              </rsm:SupplyChainTradeTransaction>
            </rsm:CrossIndustryInvoice>
            """;

        HtmlToPdf converter = new HtmlToPdf();

        // PDF/A-3A with PDF/UA-1: an archival carrier whose visible invoice is also accessible
        converter.Options.PdfStandard = PdfStandard.PdfA3A;
        converter.Options.AccessibilityStandard = PdfUAStandard.UA1;
        converter.Options.Title = "Invoice RE-2026-0816";
        converter.Options.Language = "en-US";

        PdfDocument doc = converter.ConvertHtmlString("""
            <h1>Invoice RE-2026-0816</h1>
            <p>13 October 2026. Contoso GmbH to Stadt Musterstadt. Buyer reference 04011000-12345-34.</p>
            <table>
              <tr><th scope="col">Item</th><th scope="col">Amount</th></tr>
              <tr><td>Hosting, October 2026</td><td>500.00 EUR</td></tr>
              <tr><td>VAT 19%</td><td>95.00 EUR</td></tr>
              <tr><td>Total</td><td>595.00 EUR</td></tr>
            </table>
            """);

        using (MemoryStream invoiceXml = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
        {
            doc.AddZugferdInvoice(invoiceXml, ZugferdProfile.XRechnung, PdfAttachmentRelationship.Alternative);
        }

        doc.Save("invoice-xrechnung-pdfa3a.pdf");
        doc.Close();
    }
}
