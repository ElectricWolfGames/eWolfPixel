using eWolfUnity3DParser.Sprites;
using eWolfUnity3DParser.Sprites.Data;
using System;
using System.Collections.Generic;

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
                            _pixel[x, y] = copy[x, y];
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

        internal Dictionary<string, PixelSet> CutFrames(SpriteSheetData spriteSheetData)
        {
            Dictionary<string, PixelSet> pixelSet = new Dictionary<string, PixelSet>();

            Dictionary<string, SpriteData> spriteFrames = spriteSheetData.SpritesMap;
            foreach (KeyValuePair<string, SpriteData> kvp in spriteFrames)
            {
                PixelSet set = Cut(kvp.Value.Rect);
                pixelSet.Add(kvp.Key, set);
            }
            return pixelSet;
        }

        private PixelSet Cut(SpriteDataRect rect)
        {
            int width = rect.Width;
            int height = rect.Height;

            PixelSet ps = new PixelSet(width, height);

            for (int i = 0; i < rect.Width; i++)
            {
                for (int j = 0; j < rect.Height; j++)
                {
                    ps.Pixels[i, j] = Pixels[i + rect.X, (512 - (rect.Y + rect.Height)) + j];
                }
            }
            return ps;
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
