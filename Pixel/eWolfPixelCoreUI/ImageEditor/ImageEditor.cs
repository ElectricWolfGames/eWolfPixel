using eWolfPixelStandard.Data;
using eWolfPixelStandard.Helpers;
using eWolfPixelStandard.Interfaces;
using eWolfPixelUI.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace eWolfPixelUI.ImageEditor
{
    public class ImageEditor
    {
        private const int ImageEditHeight = ImageHeight - 2;
        private const int ImageEditWidth = ImageWidth - 2;
        private const int ImageHeight = 500;
        private const int ImageOffSetX = 2;
        private const int ImageOffSetY = 2;
        private const int ImageWidth = 400;
        private readonly ColorSelection _colorSelection = new ColorSelection();
        private readonly int _currentDirection = 0;
        private readonly FrameHolder[,] _frameHolder = new FrameHolder[8, 4];
        private int _currentFrame = 0;
        private IEditable _itemsBase = null;
        private int _scale = 10;

        public ImageEditor()
        {
        }

        public PictureBox ColorImage { get; set; }

        public PictureBox ColorPreviewImage
        {
            set
            {
                _colorSelection.ColorPreviewImage = value;
                _colorSelection.Init();
            }
        }

        public PictureBox EditImage { get; set; }

        public FrameHolder FrameHolder
        {
            get
            {
                if (_frameHolder[_currentDirection, _currentFrame] == null)
                {
                    _frameHolder[_currentDirection, _currentFrame] = new FrameHolder(_itemsBase.FrameSize);
                }

                return _frameHolder[_currentDirection, _currentFrame];
            }
        }

        public PictureBox PreviewImage { get; set; }

        private bool ShowGridPixels
        {
            get
            {
                return (_scale > 4);
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

        internal void ClickImage(Point localMousePosition, MouseButtons button)
        {
            if (button == MouseButtons.Right)
            {
                PickColorFromEditImage(localMousePosition);
                return;
            }

            Point pixelPoint = ConvertToPixelPoint(localMousePosition);
            _itemsBase.SetColor(pixelPoint, _colorSelection.CurrentColor);
            DrawFrame();
            ShowFrame();
        }

        internal void ClickImageColor(Point localMousePosition)
        {
            PickColorFromColorImage(localMousePosition);
        }

        internal Image GetFrame(int direction, int frame)
        {
            if (_frameHolder[direction, frame] == null)
            {
                _frameHolder[direction, frame] = new FrameHolder(_itemsBase.FrameSize);
            }

            if (_frameHolder[direction, frame].PreviewImage == null)
            {
                _frameHolder[direction, frame].PreviewImage = new Bitmap(64, 64);
            }

            return _frameHolder[direction, frame].PreviewImage;
        }

        internal void KeyPressed(KeyPressEventArgs e)
        {
            if (e.KeyChar == '1'
                || e.KeyChar == '2'
                || e.KeyChar == '3'
                || e.KeyChar == '4'
                || e.KeyChar == '5'
                || e.KeyChar == '6'
                || e.KeyChar == '7'
                || e.KeyChar == '8'
                || e.KeyChar == '9')
            {
                _colorSelection.SetIndex(int.Parse(e.KeyChar.ToString()));
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
            if (mouseEventArgs.Button == MouseButtons.Left
                || mouseEventArgs.Button == MouseButtons.Right)
            {
                ClickImage(localMousePosition, mouseEventArgs.Button);
            }
        }

        internal void MoveInImageColor(Point localMousePosition, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button == MouseButtons.Left
                || mouseEventArgs.Button == MouseButtons.Right)
            {
                PickColorFromColorImage(localMousePosition);
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

        internal void PickColorFromEditImage(Point localMousePosition)
        {
            Point pixelPoint = ConvertToPixelPoint(localMousePosition);
            _colorSelection.CurrentColor = _itemsBase.GetColor(pixelPoint);
        }

        internal void SetItem(IEditable item)
        {
            _itemsBase = item;
            DrawFrame();
            ShowFrame();
        }

        private void CheckItem()
        {
            if (_frameHolder[_currentDirection, _currentFrame] != null)
            {
                _frameHolder[_currentDirection, _currentFrame].Check(_itemsBase.FrameSize);
            }
            else
            {
                _frameHolder[_currentDirection, _currentFrame] = new FrameHolder(_itemsBase.FrameSize);
            }

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
                for (int x = 0; x < width * _scale; x += _scale)
                {
                    int mainX = x + ImageOffSetX;
                    if (mainX >= ImageEditWidth)
                        continue;

                    for (int y = 0; y < height * _scale; y++)
                    {
                        int mainY = y + ImageOffSetY;
                        if (mainY >= ImageEditHeight)
                            continue;

                        image.SetPixel(mainX, mainY, Color.Black);
                    }
                }

                for (int y = 0; y < height * _scale; y += _scale)
                {
                    int mainY = y + ImageOffSetY;
                    if (mainY >= ImageEditHeight)
                        continue;

                    for (int x = 0; x < width * _scale; x++)
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

        public void SetDirection(Directions8Way dir)
        {
            _itemsBase.Direction = Directions8WayHelper.GetDirectionIndex(dir);
            DrawFrame();
            ShowFrame();
        }

        private void DrawFrame()
        {
            CheckItem();

            Pixel[,] pixels = _itemsBase.PixelArray;
            for (int i = 0; i < _itemsBase.FrameSize.FrameWidth; i++)
            {
                for (int j = 0; j < _itemsBase.FrameSize.FrameHeight; j++)
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

        private void PickColorFromColorImage(Point localMousePosition)
        {
            Bitmap image = new Bitmap(ColorImage.Image);
            try
            {
                Color col = image.GetPixel(localMousePosition.X, localMousePosition.Y);
                _colorSelection.CurrentColor = PixelHelper.Create(col);
            }
            catch (Exception ex)
            {
                // fail safe
                int i = 0;
                i++; ;
            }
        }

        private void ShowFrame()
        {
            EditImage.Image = FrameHolder.Image;
            PreviewImage.Image = FrameHolder.PreviewImage;
        }
    }
}
