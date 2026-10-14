using SelectPdf.Universal;

WordToPdf converter = new WordToPdf();

// PDF/A-2b: archival output, with every font embedded
converter.Options.PdfStandard = PdfStandard.PdfA2B;

// document metadata, written into the archived file
converter.Options.PdfDocumentInformation.Title = "Board meeting minutes, October 2026";
converter.Options.PdfDocumentInformation.Author = "Company secretary";
converter.Options.PdfDocumentInformation.Subject = "Minutes of the board meeting of 8 October 2026";

// the format is taken from the file extension
PdfDocument doc = converter.ConvertFile("board-minutes.docx");
doc.Save("board-minutes-pdfa2b.pdf");
doc.Close();
