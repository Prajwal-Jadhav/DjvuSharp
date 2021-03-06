using DjvuSharp;
using DjvuSharp.Enums;
using DjvuSharp.Rendering;

const string djvuFile = @"C:\Users\prajwalj\Desktop\DjvuSharp\assets\boy_and_chicken.djvu";
const string targetFile = @"C:\Users\prajwalj\Desktop\chicken.ppm";

DjvuDocument document = DjvuDocument.Create(djvuFile);

DjvuPage page = new DjvuPage(document, 1);

Rectangle pageRect = new Rectangle(0, 0, page.Width, page.Height);
Rectangle renderRect = new Rectangle(0, 0, page.Width, page.Height);

using (var renderEngine = RenderEngineFactory.CreateRenderEngine(PixelFormatStyle.RGB24))
{
    renderEngine.SetRowOrder(true);

    byte[] imagePixels = renderEngine.RenderPage(page, RenderMode.COLOR, pageRect, renderRect);

    using (BinaryWriter bw = new BinaryWriter(File.Open(targetFile, FileMode.OpenOrCreate)))
    {
        foreach (byte i in imagePixels)
        {
            bw.Write(i);
        }
    }
}