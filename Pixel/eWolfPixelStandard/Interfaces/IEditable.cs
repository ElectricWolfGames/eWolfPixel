using eWolfPixelStandard.Data;
using System.Drawing;

namespace eWolfPixelStandard.Interfaces
{
    public interface IEditable
    {
        Pixel[,] PixelArray { get; }

        void SetColor(int x, int y, Pixel color);

        void SetColor(Point pixelPoint, Pixel color);

        Pixel GetColor(Point pixelPoint);

        int CurrentFrame { get; set; }

        int Direction { get; set; }

        IFrameSize FrameSize { get; }
    }
}
