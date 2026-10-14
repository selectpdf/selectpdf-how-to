using SelectPdf.Universal;

static class MergeFolder
{
    public static void Run()
    {
        // a folder of PDFs (made here so the sample runs on its own)
        Directory.CreateDirectory("inbox");
        HtmlToPdf converter = new HtmlToPdf();
        foreach (string month in new[] { "01-january", "02-february", "03-march" })
        {
            PdfDocument statement = converter.ConvertHtmlString($"<h1>Statement {month}</h1>");
            statement.Save(Path.Combine("inbox", $"{month}.pdf"));
            statement.Close();
        }

        // merge every PDF in the folder, in file name order
        string[] files = Directory.GetFiles("inbox", "*.pdf").Order(StringComparer.Ordinal).ToArray();

        PdfDocument merged = new PdfDocument();
        foreach (string file in files)
            merged.Append(file);

        merged.Save("statements-q1.pdf");
        merged.Close();
    }
}
