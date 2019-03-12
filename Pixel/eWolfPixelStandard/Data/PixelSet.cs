using System;
using System.Drawing;
using eWolfPixelStandard.Items;

namespace eWolfPixelStandard.Data
{
    [Serializable]
    public class PixelSet
    {
        private readonly Pixel[,] _pixel;

        public PixelSet(int width, int height)
        {
            Width = width;
            Height = height;

            _pixel = new Pixel[Width, Height];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    _pixel[x, y] = new Pixel(0, 0, 0, 0);
                }
            }
        }

        public int Height { get; set; }

        public Pixel[,] Pixels
        {
            get
            {
                return _pixel;
            }
        }

        public int Width { get; set; }

        internal void SetPixel(int x, int y, Pixel color)
        {
            if (x < 0 || y < 0)
                return;

            if (x >= Width || y >= Height)
                return;

            _pixel[x, y] = color;
        }
    }
}
