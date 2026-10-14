using SelectPdf.Universal;

static class MergeInMemory
{
    public static void Run()
    {
        // PDFs that arrive as bytes: uploads, a database column, a blob store
        List<byte[]> files = [File.ReadAllBytes("a.pdf"), File.ReadAllBytes("b.pdf")];

        PdfDocument merged = new PdfDocument();
        List<MemoryStream> streams = [];
        foreach (byte[] file in files)
        {
            MemoryStream stream = new MemoryStream(file);
            streams.Add(stream);
            merged.Append(stream);
        }

        // Save() without a file name returns the merged PDF as bytes, ready for an HTTP response
        byte[] result = merged.Save();
        merged.Close();
        streams.ForEach(s => s.Dispose());

        File.WriteAllBytes("merged-in-memory.pdf", result);
    }
}
