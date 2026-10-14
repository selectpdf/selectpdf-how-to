using SelectPdf.Universal;

static class ExistingPdfToXRechnung
{
    public static void Run()
    {
        // stands in for an invoice your system already produced as a PDF, and for its XML
        HtmlToPdf converter = new HtmlToPdf();
        PdfDocument plain = converter.ConvertHtmlString(
            "<h1>Invoice RE-2026-0817</h1><p>13 October 2026. Contoso GmbH to Stadt Musterstadt. " +
            "Buyer reference 04011000-12345-34.</p><p>Software licence: 2,000.00 EUR<br>" +
            "VAT 19%: 380.00 EUR<br><b>Total: 2,380.00 EUR</b></p>");
        plain.Save("invoice-0817.pdf");
        plain.Close();
        File.WriteAllText("invoice-0817.xml", """
            <?xml version="1.0" encoding="UTF-8"?>
            <rsm:CrossIndustryInvoice xmlns:rsm="urn:un:unece:uncefact:data:standard:CrossIndustryInvoice:100"
              xmlns:ram="urn:un:unece:uncefact:data:standard:ReusableAggregateBusinessInformationEntity:100"
              xmlns:udt="urn:un:unece:uncefact:data:standard:UnqualifiedDataType:100">
              <rsm:ExchangedDocumentContext><ram:GuidelineSpecifiedDocumentContextParameter>
                <ram:ID>urn:cen.eu:en16931:2017#compliant#urn:xeinkauf.de:kosit:xrechnung_3.0</ram:ID>
              </ram:GuidelineSpecifiedDocumentContextParameter></rsm:ExchangedDocumentContext>
              <rsm:ExchangedDocument>
                <ram:ID>RE-2026-0817</ram:ID><ram:TypeCode>380</ram:TypeCode>
                <ram:IssueDateTime><udt:DateTimeString format="102">20261013</udt:DateTimeString></ram:IssueDateTime>
              </rsm:ExchangedDocument>
              <rsm:SupplyChainTradeTransaction>
                <ram:IncludedSupplyChainTradeLineItem>
                  <ram:AssociatedDocumentLineDocument><ram:LineID>1</ram:LineID></ram:AssociatedDocumentLineDocument>
                  <ram:SpecifiedTradeProduct><ram:Name>Software licence</ram:Name></ram:SpecifiedTradeProduct>
                  <ram:SpecifiedLineTradeSettlement><ram:SpecifiedTradeSettlementLineMonetarySummation>
                    <ram:LineTotalAmount>2000.00</ram:LineTotalAmount>
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
                    <ram:TaxBasisTotalAmount>2000.00</ram:TaxBasisTotalAmount>
                    <ram:TaxTotalAmount currencyID="EUR">380.00</ram:TaxTotalAmount>
                    <ram:GrandTotalAmount>2380.00</ram:GrandTotalAmount>
                    <ram:DuePayableAmount>2380.00</ram:DuePayableAmount>
                  </ram:SpecifiedTradeSettlementHeaderMonetarySummation>
                </ram:ApplicableHeaderTradeSettlement>
              </rsm:SupplyChainTradeTransaction>
            </rsm:CrossIndustryInvoice>
            """);

        // load the existing invoice and make it an archival PDF/A-3 document
        PdfDocument doc = new PdfDocument("invoice-0817.pdf");
        doc.ConvertToPdfA(PdfStandard.PdfA3B);

        // embed the XML from its file; it is read immediately and embedded as xrechnung.xml
        doc.AddZugferdInvoice("invoice-0817.xml", ZugferdProfile.XRechnung,
            PdfAttachmentRelationship.Alternative);

        doc.Save("invoice-0817-xrechnung.pdf");
        doc.Close();
    }
}
