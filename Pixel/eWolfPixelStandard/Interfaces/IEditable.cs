using eWolfPixelStandard.Items;
using System.Drawing;

namespace eWolfPixelStandard.Interfaces
{
    public interface IEditable
    {
        Pixel[,] PixelArray { get; }

        void SetColor(int x, int y, Pixel color);

        void SetColor(Point pixelPoint, Pixel color);
    }
}
