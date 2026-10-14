using System.Buffers.Binary;
using SelectPdf.Universal;

// A browser window 1280 px wide. A height of 0 (the default) means auto:
// the image is as tall as the whole page, not just the first screen.
HtmlToImage converter = new HtmlToImage();
converter.WebPageWidth = 1280;
converter.WebPageHeight = 0;

// The screenshot comes back as a byte array, PNG by default.
byte[] png = converter.ConvertUrl("https://selectpdf.com");
File.WriteAllBytes("full-page.png", png);

// The PNG header holds the size: width at byte 16, height at byte 20.
int width = BinaryPrimitives.ReadInt32BigEndian(png.AsSpan(16));
int height = BinaryPrimitives.ReadInt32BigEndian(png.AsSpan(20));
Console.WriteLine($"full-page.png: {width} x {height} px");
