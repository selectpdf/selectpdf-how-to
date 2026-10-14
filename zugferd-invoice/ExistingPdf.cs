using SelectPdf.Universal;

static class ExistingPdf
{
    public static void Run()
    {
        // an invoice that already exists as a PDF, and its XML (MINIMUM profile) as a file
        PdfDocument original = new HtmlToPdf().ConvertHtmlString(
            "<h1>Invoice 2026-002</h1><p>Contoso GmbH to Fabrikam GmbH. Total due: 119.00 EUR.</p>");
        original.Save("invoice-2026-002.pdf");
        original.Close();

        File.WriteAllText("invoice-2026-002.xml", """
            <?xml version="1.0" encoding="UTF-8"?>
            <rsm:CrossIndustryInvoice xmlns:rsm="urn:un:unece:uncefact:data:standard:CrossIndustryInvoice:100" xmlns:ram="urn:un:unece:uncefact:data:standard:ReusableAggregateBusinessInformationEntity:100" xmlns:udt="urn:un:unece:uncefact:data:standard:UnqualifiedDataType:100">
              <rsm:ExchangedDocumentContext><ram:GuidelineSpecifiedDocumentContextParameter><ram:ID>urn:factur-x.eu:1p0:minimum</ram:ID></ram:GuidelineSpecifiedDocumentContextParameter></rsm:ExchangedDocumentContext>
              <rsm:ExchangedDocument><ram:ID>2026-002</ram:ID><ram:TypeCode>380</ram:TypeCode><ram:IssueDateTime><udt:DateTimeString format="102">20261013</udt:DateTimeString></ram:IssueDateTime></rsm:ExchangedDocument>
              <rsm:SupplyChainTradeTransaction>
                <ram:ApplicableHeaderTradeAgreement>
                  <ram:SellerTradeParty><ram:Name>Contoso GmbH</ram:Name><ram:PostalTradeAddress><ram:CountryID>DE</ram:CountryID></ram:PostalTradeAddress><ram:SpecifiedTaxRegistration><ram:ID schemeID="VA">DE123456789</ram:ID></ram:SpecifiedTaxRegistration></ram:SellerTradeParty>
                  <ram:BuyerTradeParty><ram:Name>Fabrikam GmbH</ram:Name></ram:BuyerTradeParty>
                </ram:ApplicableHeaderTradeAgreement>
                <ram:ApplicableHeaderTradeDelivery/>
                <ram:ApplicableHeaderTradeSettlement>
                  <ram:InvoiceCurrencyCode>EUR</ram:InvoiceCurrencyCode>
                  <ram:SpecifiedTradeSettlementHeaderMonetarySummation><ram:TaxBasisTotalAmount>100.00</ram:TaxBasisTotalAmount><ram:TaxTotalAmount currencyID="EUR">19.00</ram:TaxTotalAmount><ram:GrandTotalAmount>119.00</ram:GrandTotalAmount><ram:DuePayableAmount>119.00</ram:DuePayableAmount></ram:SpecifiedTradeSettlementHeaderMonetarySummation>
                </ram:ApplicableHeaderTradeSettlement>
              </rsm:SupplyChainTradeTransaction>
            </rsm:CrossIndustryInvoice>
            """);

        // load the PDF and make it PDF/A-3
        PdfDocument doc = new PdfDocument("invoice-2026-002.pdf");
        doc.ConvertToPdfA(PdfStandard.PdfA3B);

        // MINIMUM is not a complete invoice: the page carries more than the XML (Data)
        doc.AddZugferdInvoice("invoice-2026-002.xml", ZugferdProfile.Minimum,
            PdfAttachmentRelationship.Data);

        doc.Save("invoice-2026-002-hybrid.pdf");
        doc.Close();
    }
}
