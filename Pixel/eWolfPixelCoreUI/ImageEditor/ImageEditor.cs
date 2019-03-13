using eWolfPixelStandard.Data;
using eWolfPixelStandard.Interfaces;
using eWolfPixelUI.Helpers;
using System.Drawing;
using System.Windows.Forms;

namespace eWolfPixelUI.ImageEditor
{
    public class ImageEditor
    {
        private const int ImageOffSetX = 2;
        private const int ImageOffSetY = 2;
        private const int ImageWidth = 400;
        private const int ImageHeight = 500;
        private const int ImageEditWidth = ImageWidth - 2;
        private const int ImageEditHeight = ImageHeight - 2;

        private readonly int _currentDirection = 0;
        private readonly FrameHolder[,] _frameHolder = new FrameHolder[8, 4];
        private Pixel _currentColor = new Pixel(255, 255, 0, 0);
        private int _currentFrame;
        private IEditable _itemsBase = null;
        private PictureBox _pictureBox;
        private PictureBox _picturePreview;
        private int _scale = 10;

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

        internal Image GetFrame(int direction, int frame)
        {
            if (_frameHolder[direction, frame] == null)
            {
                _frameHolder[direction, frame] = new FrameHolder();
            }

            if (_frameHolder[direction, frame].PreviewImage == null)
            {
                _frameHolder[direction, frame].PreviewImage = new Bitmap(64, 64);
            }

            return _frameHolder[direction, frame].PreviewImage;
        }

        internal void KeyPressed(KeyPressEventArgs e)
        {
            if (e.KeyChar == '1')
            {
                _currentColor = new Pixel(255, 0, 0, 0);
            }
            if (e.KeyChar == '2')
            {
                _currentColor = new Pixel(0, 0, 0, 0);
            }
            if (e.KeyChar == '3')
            {
                _currentColor = new Pixel(255, 255, 0, 0);
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

        internal void MoveWheelImage(Point localMousePosition, int wheelDelta)
        {
            _scale += wheelDelta;
            if (_scale < 0)
                _scale = 1;

            FrameHolder.Image = CreateDefaultImage(400, 500);
            FrameHolder.Color = null;
            DrawFrame();
            ShowFrame();
        }

        internal void SetItem(IEditable item)
        {
            _itemsBase = item;
        }

        private void CheckItem()
        {
            if (FrameHolder.Image == null)
            {
                FrameHolder.Image = CreateDefaultImage(ImageWidth, ImageHeight);
            }

            if (FrameHolder.PreviewImage == null)
            {
                FrameHolder.PreviewImage = new Bitmap(64, 64);
            }
        }

        private Bitmap CreateDefaultImage(int width, int height)
        {
            Bitmap image = new Bitmap(width, height);

            for (int i = 0; i < width - (ImageOffSetX * 2); i++)
            {
                image.SetPixel(i + ImageOffSetX, 0, Color.Black);
                image.SetPixel(i + ImageOffSetX, 1, Color.Black);
                image.SetPixel(i + ImageOffSetX, height - 1, Color.Black);
                image.SetPixel(i + ImageOffSetX, height - 2, Color.Black);
            }

            for (int i = 0; i < height - (ImageOffSetY * 2); i++)
            {
                image.SetPixel(0, i + ImageOffSetX, Color.Black);
                image.SetPixel(1, i + ImageOffSetX, Color.Black);
                image.SetPixel(width - 1, i + ImageOffSetX, Color.Black);
                image.SetPixel(width - 2, i + ImageOffSetX, Color.Black);
            }

            for (int i = 0; i < width - (ImageOffSetX * 2); i++)
            {
                for (int j = 0; j < height - (ImageOffSetY * 2); j++)
                {
                    image.SetPixel(i + ImageOffSetX, j + ImageOffSetY, Color.White);
                }
            }

            if (ShowGridPixels)
            {
                for (int x = 0; x < 24 * _scale; x += _scale)
                {
                    int mainX = x + ImageOffSetX;
                    if (mainX >= ImageEditWidth)
                        continue;

                    for (int y = 0; y < 24 * _scale; y++)
                    {
                        int mainY = y + ImageOffSetY;
                        if (mainY >= ImageEditHeight)
                            continue;

                        image.SetPixel(mainX, mainY, Color.Black);
                    }
                }

                for (int y = 0; y < 24 * _scale; y += _scale)
                {
                    int mainY = y + ImageOffSetY;
                    if (mainY >= ImageEditHeight)
                        continue;

                    for (int x = 0; x < 24 * _scale; x++)
                    {
                        int mainX = x + ImageOffSetX;
                        if (mainX >= ImageEditWidth)
                            continue;

                        image.SetPixel(mainX, mainY, Color.Black);
                    }
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
            int scaleX = x * _scale;
            int scaleY = y * _scale;
            int start = ShowGridPixels ? 1 : 0;

            for (int i = start; i < _scale; i++)
            {
                int mainX = scaleX + i + ImageOffSetX;
                if (mainX >= ImageEditWidth)
                    continue;

                for (int j = start; j < _scale; j++)
                {
                    int mainY = scaleY + j + ImageOffSetY;
                    if (mainY >= ImageEditHeight)
                        continue;

                    FrameHolder.Image.SetPixel(mainX, mainY, col);
                }
            }
        }

        private void ShowFrame()
        {
            _pictureBox.Image = FrameHolder.Image;
            _picturePreview.Image = FrameHolder.PreviewImage;
        }

        private bool ShowGridPixels
        {
            get
            {
                return (_scale > 4);
            }
        }
    }
}
