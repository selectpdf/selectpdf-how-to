using SelectPdf.Universal;

static class NotesPages
{
    public static void Run()
    {
        PowerPointToPdf converter = new PowerPointToPdf();

        // one page per slide, with the speaker notes below the slide
        converter.Options.Publish = PowerPointPublish.NotesPages;

        PdfDocument doc = converter.ConvertFile("presentation.pptx");
        doc.Save("presentation-notes.pdf");
        doc.Close();
    }
}
