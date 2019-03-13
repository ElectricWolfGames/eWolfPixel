using eWolfPixelStandard.Data;
using eWolfPixelStandard.Interfaces;
using eWolfPixelUI.Helpers;
using System.Drawing;
using System.Windows.Forms;

namespace eWolfPixelUI.ImageEditor
{
    public class ImageEditor
    {
        private readonly int _currentDirection = 0;
        private readonly FrameHolder[,] _frameHolder = new FrameHolder[8, 4];
        private readonly ImageHolder _imageHolder = new ImageHolder();
        private readonly float _scale = 10;
        private Pixel _currentColor = new Pixel(255, 255, 0, 0);
        private int _currentFrame;
        private IEditable _itemsBase = null;

        private PictureBox _pictureBox;
        private PictureBox _picturePreview;

        public ImageEditor()
        {
        }

        public PictureBox EditImage
        {
            set
            {
                _pictureBox = value;
            }
        }

        public FrameHolder FrameHolder
        {
            get
            {
                if (_frameHolder[_currentDirection, _currentFrame] == null)
                    _frameHolder[_currentDirection, _currentFrame] = new FrameHolder();

                return _frameHolder[_currentDirection, _currentFrame];
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
            Point pixelPoint = ConvertToPixelPoint(localMousePosition);
            _itemsBase.SetColor(pixelPoint, _currentColor);
            DrawFrame();

            ShowFrame();
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
                    _itemsBase.CurrentFrame = _currentFrame;
                    DrawFrame();
                    ShowFrame();
                }
            }
            if (e.KeyChar == 'e')
            {
                if (_currentFrame < 3)
                {
                    _currentFrame += 1;
                    _itemsBase.CurrentFrame = _currentFrame;
                    DrawFrame();
                    ShowFrame();
                }
            }
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

        private void CheckItem()
        {
            if (FrameHolder.Image == null)
            {
                FrameHolder.Image = CreateDefaultImage(600, 600);
            }

            if (FrameHolder.PreviewImage == null)
            {
                FrameHolder.PreviewImage = new Bitmap(64, 64);
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

        private void DrawFrame()
        {
            CheckItem();

            Pixel[,] pixels = _itemsBase.PixelArray;

            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    Color col = PixelHelper.PixelColor(pixels[i, j]);

                    if (FrameHolder.Color[i, j] != col)
                    {
                        FrameHolder.PreviewImage.SetPixel(i, j, col);

                        FrameHolder.Color[i, j] = col;
                        DrawScaledPixel(i, j, col);
                    }
                }
            }
        }

        private void DrawScaledPixel(int x, int y, Color col)
        {
            int scaleX = (int)(x * _scale);
            int scaleY = (int)(y * _scale);

            for (int i = 1; i < _scale; i++)
            {
                for (int j = 1; j < _scale; j++)
                {
                    FrameHolder.Image.SetPixel(scaleX + i, scaleY + j, col);
                }
            }
        }

        private void ShowFrame()
        {
            _pictureBox.Image = FrameHolder.Image;
            _picturePreview.Image = FrameHolder.PreviewImage;
        }
    }
}
