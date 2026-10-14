using SelectPdf.Universal;

static class AsyncToStream
{
    public static async Task Run()
    {
        HtmlToImage converter = new HtmlToImage(1280, 800);

        // stop the conversion if it takes longer than 30 seconds
        using CancellationTokenSource timeout = new CancellationTokenSource(TimeSpan.FromSeconds(30));
        byte[] png = await converter.ConvertUrlAsync("https://selectpdf.com", timeout.Token);

        // write the bytes to any stream: a file, a response body, a blob upload
        await using FileStream file = File.Create("webpage-async.png");
        await file.WriteAsync(png, timeout.Token);
    }
}
