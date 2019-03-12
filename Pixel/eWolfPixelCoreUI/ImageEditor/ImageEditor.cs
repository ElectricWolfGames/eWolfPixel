using System;
using System.Drawing;
using System.Windows.Forms;
using eWolfPixelStandard.Interfaces;
using eWolfPixelStandard.Items;
using eWolfPixelUI.Helpers;

namespace eWolfPixelUI.ImageEditor
{
    public class ImageEditor
    {
        private readonly Color[,] _color = new Color[64, 64];
        private readonly Bitmap _image;
        private readonly ImageHolder _imageHolder = new ImageHolder();
        private readonly Bitmap _previewImage;
        private Pixel _currentColor = new Pixel(255, 255, 0, 0);
        private IEditable _itemsBase = null;
        private PictureBox _pictureBox;
        private PictureBox _picturePreview;

        public ImageEditor()
        {
            for (int i = 0; i < 64; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    _color[i, j] = Color.White;
                }
            }
            _image = new Bitmap(600, 600);
            _previewImage = new Bitmap(64, 64);
        }

        public PictureBox EditImage
        {
            set
            {
                _pictureBox = value;
            }
        }

        public PictureBox PreviewImage
        {
            set
            {
                _picturePreview = value;
            }
        }

        internal void ClickImage(Point localMousePosition)
        {
            float scale = 20;
            float grid = 1 * scale;
            float x2 = localMousePosition.X;
            float y2 = localMousePosition.Y;

            x2 /= scale;
            y2 /= scale;

            int x3 = (int)x2;
            int y3 = (int)y2;

            _itemsBase.SetColor(x3, y3, _currentColor);

            Pixel[,] pixels = _itemsBase.PixelArray;

            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Color col = PixelHelper.PixelColor(pixels[i, j]);
                    if (_color[i, j] != col)
                    {
                        _color[i, j] = col;
                        float xx = i * scale;
                        float yy = j * scale;
                        for (int i2 = 0; i2 < grid; i2++)
                        {
                            for (int j2 = 0; j2 < grid; j2++)
                            {
                                _image.SetPixel((int)xx + i2, (int)yy + j2, col);
                                _previewImage.SetPixel(i, j, col);
                            }
                        }
                    }
                }
            }

            for (float x = 0; x < _image.Width; x += grid)
            {
                for (int y = 0; y < _image.Height; y++)
                {
                    _image.SetPixel((int)x, y, System.Drawing.Color.Black);
                }
            }

            for (float y = 0; y < _image.Height; y += grid)
            {
                for (float x = 0; x < _image.Width; x++)
                {
                    _image.SetPixel((int)x, (int)y, System.Drawing.Color.Black);
                }
            }

            _pictureBox.Image = _image;
            _picturePreview.Image = _previewImage;
        }

        internal void KeyPressed(KeyPressEventArgs e)
        {
            if (e.KeyChar == '1')
            {
                _currentColor = new Pixel(255, 0, 0, 0);
            }
            if (e.KeyChar == '2')
            {
                _currentColor = new Pixel(255, 255, 0, 0);
            }
            if (e.KeyChar == '3')
            {
                _currentColor = new Pixel(255, 0, 255, 0);
            }
            if (e.KeyChar == '4')
            {
                _currentColor = new Pixel(255, 0, 0, 255);
            }
            if (e.KeyChar == '5')
            {
                _currentColor = new Pixel(255, 255, 255, 255);
            }
        }

        internal void SetItem(IEditable item)
        {
            _itemsBase = item;
        }
    }
}
