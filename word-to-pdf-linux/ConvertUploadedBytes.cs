using SelectPdf.Universal;

static class ConvertUploadedBytes
{
    public static void Run()
    {
        // a document held in memory, such as a file uploaded to a web app
        byte[] upload = File.ReadAllBytes("report.docx");

        // the format is detected from the content (docx, doc, rtf, WordML)
        WordToPdf converter = new WordToPdf();
        PdfDocument doc = converter.ConvertBytes(upload);

        // Save() without arguments returns the PDF as a byte array
        byte[] pdf = doc.Save();
        doc.Close();

        File.WriteAllBytes("report-from-bytes.pdf", pdf);
    }
}
