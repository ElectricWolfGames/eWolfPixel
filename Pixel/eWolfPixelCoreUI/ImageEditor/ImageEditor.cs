using eWolfPixelStandard.Data;
using eWolfPixelStandard.Interfaces;
using eWolfPixelUI.Helpers;
using System.Drawing;
using System.Windows.Forms;

namespace eWolfPixelUI.ImageEditor
{
    public class ImageEditor
    {
        private readonly Color[,] _color = new Color[64, 64];
        private readonly ImageHolder _imageHolder = new ImageHolder();

        private readonly float _scale = 10;
        private Pixel _currentColor = new Pixel(255, 255, 0, 0);
        private int _currentFrame = 0;
        private readonly int _currentDirection = 0;
        private readonly Bitmap _image;
        private Bitmap[,] _imageArray;
        private Bitmap[,] _previewImageArray;
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

        public Point ConvertToPixelPoint(Point localMousePosition)
        {
            Point p = new Point();
            float x = localMousePosition.X / _scale;
            float y = localMousePosition.Y / _scale;
            p.X = (int)x;
            p.Y = (int)y;
            return p;
        }

        internal void ClickImage(Point localMousePosition)
        {
            if (_imageArray == null)
                CreateAllDefaultImage(600, 600);

            Point pixelPoint = ConvertToPixelPoint(localMousePosition);
            _itemsBase.SetColor(pixelPoint, _currentColor);

            Pixel[,] pixels = _itemsBase.PixelArray;

            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    Color col = PixelHelper.PixelColor(pixels[i, j]);

                    if (_color[i, j] != col)
                    {
                        _previewImageArray[_currentDirection, _currentFrame].SetPixel(i, j, col);

                        _color[i, j] = col;
                        DrawScaledPixel(i, j, col);
                    }
                }
            }

            _pictureBox.Image = _imageArray[_currentDirection, _currentFrame];
            _picturePreview.Image = _previewImageArray[_currentDirection, _currentFrame];
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

            if (e.KeyChar == 'q')
            {
                if (_currentFrame > 0)
                {
                    _currentFrame -= 1;
                    ShowFrame();
                }
            }
            if (e.KeyChar == 'e')
            {
                if (_currentFrame < 3)
                {
                    _currentFrame += 1;
                    ShowFrame();
                }
            }
        }

        private void ShowFrame()
        {
            _itemsBase.CurrentFrame = _currentFrame;
            _pictureBox.Image = _imageArray[_currentDirection, _currentFrame];
            _picturePreview.Image = _previewImageArray[_currentDirection, _currentFrame];
        }

        internal void MoveInImage(Point localMousePosition, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                ClickImage(localMousePosition);
            }
        }

        internal void SetItem(IEditable item)
        {
            _itemsBase = item;
        }

        private void CreateAllDefaultImage(int width, int height)
        {
            _imageArray = new Bitmap[8, 4];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _imageArray[i, j] = CreateDefaultImage(width, height);
                }
            }
            _previewImageArray = new Bitmap[8, 4];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _previewImageArray[i, j] = new Bitmap(24, 24);
                }
            }
        }

        private Bitmap CreateDefaultImage(int width, int height)
        {
            Bitmap image = new Bitmap(width, height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    image.SetPixel(i, j, Color.White);
                }
            }

            for (float x = 0; x < 24 * _scale; x += _scale)
            {
                for (int y = 0; y < 24 * _scale; y++)
                {
                    image.SetPixel((int)x, y, Color.Black);
                }
            }

            for (float y = 0; y < 24 * _scale; y += _scale)
            {
                for (float x = 0; x < 24 * _scale; x++)
                {
                    image.SetPixel((int)x, (int)y, Color.Black);
                }
            }
            return image;
        }

        private void DrawScaledPixel(int x, int y, Color col)
        {
            int scaleX = (int)(x * _scale);
            int scaleY = (int)(y * _scale);

            for (int i = 1; i < _scale; i++)
            {
                for (int j = 1; j < _scale; j++)
                {
                    _imageArray[_currentDirection, _currentFrame].SetPixel(scaleX + i, scaleY + j, col);
                }
            }
        }
    }
}
