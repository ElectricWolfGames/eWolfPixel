using System;
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
            for (int x = 0; x < pixelSet.Width - 1; x++)
            {
                for (int y = 0; y < pixelSet.Height - 1; y++)
                {
                    if (!pixelSet.Pixels[x, y].IsEmpty && !pixelSet.Pixels[x, y].IsBlackout)
                    {
                        if (pixelSet.Pixels[x + 1, y].IsEmpty)
                        {
                            pixelSet.SetPixel(x + 1, y, Pixel.Black);
                        }
                        if (pixelSet.Pixels[x - 1, y].IsEmpty)
                        {
                            pixelSet.SetPixel(x - 1, y, Pixel.Black);
                        }
                        if (pixelSet.Pixels[x, y + 1].IsEmpty)
                        {
                            pixelSet.SetPixel(x, y + 1, Pixel.Black);
                        }
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
