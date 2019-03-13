using eWolfPixelStandard.Data;
using System.Drawing;

namespace eWolfPixelUI.Helpers
{
    public static class PixelHelper
    {
        internal static Color PixelColor(Pixel pixel)
        {
            return Color.FromArgb(pixel.A, pixel.R, pixel.G, pixel.B);
        }
    }
}
