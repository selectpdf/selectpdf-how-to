using System.Text;
using SelectPdf.Universal;

static class XRechnungWithCustomMetadata
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
                <ram:ID>RE-2026-0818</ram:ID><ram:TypeCode>380</ram:TypeCode>
                <ram:IssueDateTime><udt:DateTimeString format="102">20261013</udt:DateTimeString></ram:IssueDateTime>
              </rsm:ExchangedDocument>
              <rsm:SupplyChainTradeTransaction>
                <ram:IncludedSupplyChainTradeLineItem>
                  <ram:AssociatedDocumentLineDocument><ram:LineID>1</ram:LineID></ram:AssociatedDocumentLineDocument>
                  <ram:SpecifiedTradeProduct><ram:Name>Support contract, Q4 2026</ram:Name></ram:SpecifiedTradeProduct>
                  <ram:SpecifiedLineTradeSettlement><ram:SpecifiedTradeSettlementLineMonetarySummation>
                    <ram:LineTotalAmount>750.00</ram:LineTotalAmount>
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
                    <ram:TaxBasisTotalAmount>750.00</ram:TaxBasisTotalAmount>
                    <ram:TaxTotalAmount currencyID="EUR">142.50</ram:TaxTotalAmount>
                    <ram:GrandTotalAmount>892.50</ram:GrandTotalAmount>
                    <ram:DuePayableAmount>892.50</ram:DuePayableAmount>
                  </ram:SpecifiedTradeSettlementHeaderMonetarySummation>
                </ram:ApplicableHeaderTradeSettlement>
              </rsm:SupplyChainTradeTransaction>
            </rsm:CrossIndustryInvoice>
            """;

        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.PdfStandard = PdfStandard.PdfA3B;
        PdfDocument doc = converter.ConvertHtmlString(
            "<h1>Invoice RE-2026-0818</h1><p>13 October 2026. Contoso GmbH to Stadt Musterstadt. " +
            "Buyer reference 04011000-12345-34.</p><p>Support contract, Q4 2026: 750.00 EUR<br>" +
            "VAT 19%: 142.50 EUR<br><b>Total: 892.50 EUR</b></p>");

        using (MemoryStream invoiceXml = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
        {
            doc.AddZugferdInvoice(invoiceXml, ZugferdProfile.XRechnung, PdfAttachmentRelationship.Alternative);
        }

        // metadata of your own, declared as an XMP extension schema so the document stays PDF/A
        Dictionary<string, string> properties = new Dictionary<string, string>();
        properties["OrderNumber"] = "PO-4711";
        properties["Department"] = "Accounts receivable";
        doc.AddXmpExtensionSchema("contoso", "urn:contoso:pdfa:invoice:1p0#",
            "Contoso invoice schema", properties);

        doc.Save("invoice-0818-xrechnung.pdf");
        doc.Close();
    }
}
