using eWolfPixelStandard.Data;
using eWolfPixelStandard.Items;
using eWolfPixelStandard.Options;

namespace eWolfPixelStandard.Helpers
{
    public static class BorderHelper
    {
        internal static void Apply(BorderStyle borderStyle, PixelSet pixelSet)
        {
            if (borderStyle == BorderStyle.Black)
            {
                ApplyBlack(pixelSet);
            }
        }

        internal static void ApplyBlack(PixelSet pixelSet)
        {
            for (int x = 0; x < pixelSet.Width; x++)
            {
                for (int y = 0; y < pixelSet.Height; y++)
                {
                    if (!pixelSet.Pixels[x, y].IsEmpty && !pixelSet.Pixels[x, y].IsBlackout)
                    {
                        if (x < pixelSet.Width - 1)
                        {
                            if (pixelSet.Pixels[x + 1, y].IsEmpty)
                            {
                                pixelSet.SetPixel(x + 1, y, Pixel.Black);
                            }
                        }
                        if (x > 0)
                        {
                            if (pixelSet.Pixels[x - 1, y].IsEmpty)
                            {
                                pixelSet.SetPixel(x - 1, y, Pixel.Black);
                            }
                        }
                        if (y < pixelSet.Height - 1)
                        {
                            if (pixelSet.Pixels[x, y + 1].IsEmpty)
                            {
                                pixelSet.SetPixel(x, y + 1, Pixel.Black);
                            }
                        }
                        if (y > 0)
                        {
                            if (pixelSet.Pixels[x, y - 1].IsEmpty)
                            {
                                pixelSet.SetPixel(x, y - 1, Pixel.Black);
                            }
                        }
                    }
                }
            }
        }
    }
}
