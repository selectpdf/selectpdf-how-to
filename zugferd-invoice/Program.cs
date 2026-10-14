using System.Text;
using SelectPdf.Universal;

string html = """
    <html lang="en">
    <head><title>Invoice 2026-001</title></head>
    <body>
      <h1>Invoice 2026-001</h1>
      <p>Contoso GmbH, Berlin, to Fabrikam GmbH, Munich. Issued on 13 October 2026.</p>
      <p>1 x Software license: 499.00 EUR. VAT 19%: 94.81 EUR. Total due: 593.81 EUR.</p>
    </body>
    </html>
    """;

// the same invoice as Cross Industry Invoice XML (EN 16931 profile)
string xml = """
    <?xml version="1.0" encoding="UTF-8"?>
    <rsm:CrossIndustryInvoice xmlns:rsm="urn:un:unece:uncefact:data:standard:CrossIndustryInvoice:100" xmlns:ram="urn:un:unece:uncefact:data:standard:ReusableAggregateBusinessInformationEntity:100" xmlns:udt="urn:un:unece:uncefact:data:standard:UnqualifiedDataType:100">
      <rsm:ExchangedDocumentContext><ram:GuidelineSpecifiedDocumentContextParameter><ram:ID>urn:cen.eu:en16931:2017</ram:ID></ram:GuidelineSpecifiedDocumentContextParameter></rsm:ExchangedDocumentContext>
      <rsm:ExchangedDocument><ram:ID>2026-001</ram:ID><ram:TypeCode>380</ram:TypeCode><ram:IssueDateTime><udt:DateTimeString format="102">20261013</udt:DateTimeString></ram:IssueDateTime></rsm:ExchangedDocument>
      <rsm:SupplyChainTradeTransaction>
        <ram:IncludedSupplyChainTradeLineItem>
          <ram:AssociatedDocumentLineDocument><ram:LineID>1</ram:LineID></ram:AssociatedDocumentLineDocument>
          <ram:SpecifiedTradeProduct><ram:Name>Software license</ram:Name></ram:SpecifiedTradeProduct>
          <ram:SpecifiedLineTradeAgreement><ram:NetPriceProductTradePrice><ram:ChargeAmount>499.00</ram:ChargeAmount></ram:NetPriceProductTradePrice></ram:SpecifiedLineTradeAgreement>
          <ram:SpecifiedLineTradeDelivery><ram:BilledQuantity unitCode="C62">1</ram:BilledQuantity></ram:SpecifiedLineTradeDelivery>
          <ram:SpecifiedLineTradeSettlement>
            <ram:ApplicableTradeTax><ram:TypeCode>VAT</ram:TypeCode><ram:CategoryCode>S</ram:CategoryCode><ram:RateApplicablePercent>19</ram:RateApplicablePercent></ram:ApplicableTradeTax>
            <ram:SpecifiedTradeSettlementLineMonetarySummation><ram:LineTotalAmount>499.00</ram:LineTotalAmount></ram:SpecifiedTradeSettlementLineMonetarySummation>
          </ram:SpecifiedLineTradeSettlement>
        </ram:IncludedSupplyChainTradeLineItem>
        <ram:ApplicableHeaderTradeAgreement>
          <ram:SellerTradeParty><ram:Name>Contoso GmbH</ram:Name><ram:PostalTradeAddress><ram:CityName>Berlin</ram:CityName><ram:CountryID>DE</ram:CountryID></ram:PostalTradeAddress><ram:SpecifiedTaxRegistration><ram:ID schemeID="VA">DE123456789</ram:ID></ram:SpecifiedTaxRegistration></ram:SellerTradeParty>
          <ram:BuyerTradeParty><ram:Name>Fabrikam GmbH</ram:Name><ram:PostalTradeAddress><ram:CityName>Munich</ram:CityName><ram:CountryID>DE</ram:CountryID></ram:PostalTradeAddress></ram:BuyerTradeParty>
        </ram:ApplicableHeaderTradeAgreement>
        <ram:ApplicableHeaderTradeDelivery/>
        <ram:ApplicableHeaderTradeSettlement>
          <ram:InvoiceCurrencyCode>EUR</ram:InvoiceCurrencyCode>
          <ram:ApplicableTradeTax><ram:CalculatedAmount>94.81</ram:CalculatedAmount><ram:TypeCode>VAT</ram:TypeCode><ram:BasisAmount>499.00</ram:BasisAmount><ram:CategoryCode>S</ram:CategoryCode><ram:RateApplicablePercent>19</ram:RateApplicablePercent></ram:ApplicableTradeTax>
          <ram:SpecifiedTradePaymentTerms><ram:DueDateDateTime><udt:DateTimeString format="102">20261112</udt:DateTimeString></ram:DueDateDateTime></ram:SpecifiedTradePaymentTerms>
          <ram:SpecifiedTradeSettlementHeaderMonetarySummation><ram:LineTotalAmount>499.00</ram:LineTotalAmount><ram:TaxBasisTotalAmount>499.00</ram:TaxBasisTotalAmount><ram:TaxTotalAmount currencyID="EUR">94.81</ram:TaxTotalAmount><ram:GrandTotalAmount>593.81</ram:GrandTotalAmount><ram:DuePayableAmount>593.81</ram:DuePayableAmount></ram:SpecifiedTradeSettlementHeaderMonetarySummation>
        </ram:ApplicableHeaderTradeSettlement>
      </rsm:SupplyChainTradeTransaction>
    </rsm:CrossIndustryInvoice>
    """;

HtmlToPdf converter = new HtmlToPdf();

// the carrier must be PDF/A-3
converter.Options.PdfStandard = PdfStandard.PdfA3B;
converter.Options.PdfDocumentInformation.Title = "Invoice 2026-001";

PdfDocument doc = converter.ConvertHtmlString(html);

// embed the XML as factur-x.xml and mark the document as an electronic invoice
using (MemoryStream invoiceXml = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
{
    doc.AddZugferdInvoice(invoiceXml, ZugferdProfile.En16931,
        PdfAttachmentRelationship.Alternative);
}

doc.Save("invoice-2026-001.pdf");
doc.Close();
