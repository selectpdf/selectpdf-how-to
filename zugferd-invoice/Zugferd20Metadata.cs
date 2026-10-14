using System.Text;
using SelectPdf.Universal;

static class Zugferd20Metadata
{
    public static void Run()
    {
        // MINIMUM profile, identified with the ZUGFeRD 2.0 guideline
        string xml = """
            <?xml version="1.0" encoding="UTF-8"?>
            <rsm:CrossIndustryInvoice xmlns:rsm="urn:un:unece:uncefact:data:standard:CrossIndustryInvoice:100" xmlns:ram="urn:un:unece:uncefact:data:standard:ReusableAggregateBusinessInformationEntity:100" xmlns:udt="urn:un:unece:uncefact:data:standard:UnqualifiedDataType:100">
              <rsm:ExchangedDocumentContext><ram:GuidelineSpecifiedDocumentContextParameter><ram:ID>urn:zugferd.de:2p0:minimum</ram:ID></ram:GuidelineSpecifiedDocumentContextParameter></rsm:ExchangedDocumentContext>
              <rsm:ExchangedDocument><ram:ID>2026-004</ram:ID><ram:TypeCode>380</ram:TypeCode><ram:IssueDateTime><udt:DateTimeString format="102">20261013</udt:DateTimeString></ram:IssueDateTime></rsm:ExchangedDocument>
              <rsm:SupplyChainTradeTransaction>
                <ram:ApplicableHeaderTradeAgreement>
                  <ram:SellerTradeParty><ram:Name>Contoso GmbH</ram:Name><ram:PostalTradeAddress><ram:CountryID>DE</ram:CountryID></ram:PostalTradeAddress><ram:SpecifiedTaxRegistration><ram:ID schemeID="VA">DE123456789</ram:ID></ram:SpecifiedTaxRegistration></ram:SellerTradeParty>
                  <ram:BuyerTradeParty><ram:Name>Fabrikam GmbH</ram:Name></ram:BuyerTradeParty>
                </ram:ApplicableHeaderTradeAgreement>
                <ram:ApplicableHeaderTradeDelivery/>
                <ram:ApplicableHeaderTradeSettlement>
                  <ram:InvoiceCurrencyCode>EUR</ram:InvoiceCurrencyCode>
                  <ram:SpecifiedTradeSettlementHeaderMonetarySummation><ram:TaxBasisTotalAmount>50.00</ram:TaxBasisTotalAmount><ram:TaxTotalAmount currencyID="EUR">9.50</ram:TaxTotalAmount><ram:GrandTotalAmount>59.50</ram:GrandTotalAmount><ram:DuePayableAmount>59.50</ram:DuePayableAmount></ram:SpecifiedTradeSettlementHeaderMonetarySummation>
                </ram:ApplicableHeaderTradeSettlement>
              </rsm:SupplyChainTradeTransaction>
            </rsm:CrossIndustryInvoice>
            """;

        HtmlToPdf converter = new HtmlToPdf();
        converter.Options.PdfStandard = PdfStandard.PdfA3B;
        PdfDocument doc = converter.ConvertHtmlString(
            "<h1>Invoice 2026-004</h1><p>Contoso GmbH to Fabrikam GmbH. Total due: 59.50 EUR.</p>");

        // the deprecated ZUGFeRD 2.0 metadata: the file is named zugferd-invoice.xml
        using (MemoryStream invoiceXml = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
        {
            doc.AddZugferdInvoice(invoiceXml, ZugferdProfile.Minimum,
                PdfAttachmentRelationship.Data, ZugferdSchema.Zugferd20);
        }

        doc.Save("invoice-2026-004-zugferd20.pdf");
        doc.Close();
    }
}
