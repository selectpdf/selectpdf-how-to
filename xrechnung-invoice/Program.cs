using System.Text;
using SelectPdf.Universal;

// the invoice as XRechnung CII XML (shortened); in your application, your invoicing system produces it
string xml = """
    <?xml version="1.0" encoding="UTF-8"?>
    <rsm:CrossIndustryInvoice xmlns:rsm="urn:un:unece:uncefact:data:standard:CrossIndustryInvoice:100"
      xmlns:ram="urn:un:unece:uncefact:data:standard:ReusableAggregateBusinessInformationEntity:100"
      xmlns:udt="urn:un:unece:uncefact:data:standard:UnqualifiedDataType:100">
      <rsm:ExchangedDocumentContext><ram:GuidelineSpecifiedDocumentContextParameter>
        <ram:ID>urn:cen.eu:en16931:2017#compliant#urn:xeinkauf.de:kosit:xrechnung_3.0</ram:ID>
      </ram:GuidelineSpecifiedDocumentContextParameter></rsm:ExchangedDocumentContext>
      <rsm:ExchangedDocument>
        <ram:ID>RE-2026-0815</ram:ID><ram:TypeCode>380</ram:TypeCode>
        <ram:IssueDateTime><udt:DateTimeString format="102">20261013</udt:DateTimeString></ram:IssueDateTime>
      </rsm:ExchangedDocument>
      <rsm:SupplyChainTradeTransaction>
        <ram:IncludedSupplyChainTradeLineItem>
          <ram:AssociatedDocumentLineDocument><ram:LineID>1</ram:LineID></ram:AssociatedDocumentLineDocument>
          <ram:SpecifiedTradeProduct><ram:Name>Website maintenance, September 2026</ram:Name></ram:SpecifiedTradeProduct>
          <ram:SpecifiedLineTradeSettlement><ram:SpecifiedTradeSettlementLineMonetarySummation>
            <ram:LineTotalAmount>1000.00</ram:LineTotalAmount>
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
            <ram:TaxBasisTotalAmount>1000.00</ram:TaxBasisTotalAmount>
            <ram:TaxTotalAmount currencyID="EUR">190.00</ram:TaxTotalAmount>
            <ram:GrandTotalAmount>1190.00</ram:GrandTotalAmount>
            <ram:DuePayableAmount>1190.00</ram:DuePayableAmount>
          </ram:SpecifiedTradeSettlementHeaderMonetarySummation>
        </ram:ApplicableHeaderTradeSettlement>
      </rsm:SupplyChainTradeTransaction>
    </rsm:CrossIndustryInvoice>
    """;

// the visible invoice, with the same content as the XML
string html = """
    <h1>Invoice RE-2026-0815</h1>
    <p>13 October 2026 · Contoso GmbH to Stadt Musterstadt · Buyer reference 04011000-12345-34</p>
    <p>Website maintenance, September 2026: 1,000.00 EUR<br>VAT 19%: 190.00 EUR<br><b>Total: 1,190.00 EUR</b></p>
    """;

// the carrier: a PDF/A-3 document
HtmlToPdf converter = new HtmlToPdf();
converter.Options.PdfStandard = PdfStandard.PdfA3B;
converter.Options.PdfDocumentInformation.Title = "Invoice RE-2026-0815";
PdfDocument doc = converter.ConvertHtmlString(html);

// embed the XML as xrechnung.xml and mark the document as an XRechnung invoice
using (MemoryStream invoiceXml = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
{
    doc.AddZugferdInvoice(invoiceXml, ZugferdProfile.XRechnung, PdfAttachmentRelationship.Alternative);
}

doc.Save("invoice-xrechnung.pdf");
doc.Close();
