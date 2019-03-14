using eWolfPixelStandard.Data;
using System;
using System.Drawing;

namespace eWolfPixelUI.Helpers
{
    public static class PixelHelper
    {
        internal static Pixel Create(Color col)
        {
            return new Pixel(col.A, col.R, col.G, col.B);
        }

        internal static Color PixelColor(Pixel pixel)
        {
            return Color.FromArgb(pixel.A, pixel.R, pixel.G, pixel.B);
        }
    }
}
