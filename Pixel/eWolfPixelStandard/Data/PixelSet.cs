using System;
using System.Drawing;
using eWolfPixelStandard.Items;

namespace eWolfPixelStandard.Data
{
    public class PixelSet
    {
        private readonly Pixel[,] _pixel;

        public PixelSet()
        {
            _pixel = new Pixel[128, 128];

            for (int x = 0; x < 128; x++)
            {
                for (int y = 0; y < 128; y++)
                {
                    _pixel[x, y] = new Pixel(0, 0, 0, 0);
                }
            }
        }

        public Pixel[,] Pixels
        {
            get
            {
                return _pixel;
            }
        }

        internal void SetPixel(int x, int y, Pixel color)
        {
            _pixel[x, y] = color;
        }
    }
}
