using eWolfPixelStandard.Items;
using System;

namespace eWolfPixelStandard.Data
{
    [Serializable]
    public class PixelSet
    {
        private Pixel[,] _pixel;

        public PixelSet(int width, int height)
        {
            Width = width;
            Height = height;

            _pixel = new Pixel[Width, Height];
            FillTransparent();
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

        internal void Rebuild(int frameWidth, int frameHeight)
        {
            if (Width == frameWidth
                && Height == frameHeight)
                return;

            Pixel[,] copy = new Pixel[Width, Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    copy[x, y] = _pixel[x, y];
                }
            }

            int oldWidth = Width;
            int oldHeight = Height;

            Width = frameWidth;
            Height = frameHeight;

            _pixel = new Pixel[Width, Height];
            FillTransparent();

            for (int x = 0; x < Width; x++)
            {
                if (x < oldWidth)
                {
                    for (int y = 0; y < Height; y++)
                    {
                        if (y < oldHeight)
                        {
                            copy[x, y] = _pixel[x, y];
                        }
                    }
                }
            }
        }

        internal void SetPixel(int x, int y, Pixel color)
        {
            if (x < 0 || y < 0)
                return;

            if (x >= Width || y >= Height)
                return;

            _pixel[x, y] = color;
        }

        private void FillTransparent()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    _pixel[x, y] = new Pixel(0, 0, 0, 0);
                }
            }
        }

        internal Pixel GetPixel(int x, int y)
        {
            if (x < 0 || y < 0)
                return Pixel.White;

            if (x >= Width || y >= Height)
                return Pixel.White;

            return _pixel[x, y];
        }
    }
}
