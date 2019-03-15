using eWolfPixelStandard.Data;
using eWolfPixelUI.Helpers;
using System.Drawing;
using System.Windows.Forms;

namespace eWolfPixelUI.ImageEditor
{
    public class ColorSelection
    {
        private const int TotalColors = 9;
        private readonly Pixel[] _pixels;
        private Bitmap _colors;
        private int _index = 0;

        public ColorSelection()
        {
            _colors = new Bitmap(20 * TotalColors, 20);
            _pixels = new Pixel[TotalColors];
            _pixels[0] = new Pixel(255, 0, 0, 0);
            _pixels[1] = new Pixel(0, 0, 0, 0);
            _pixels[2] = new Pixel(255, 255, 255, 255);
            _pixels[3] = new Pixel(255, 255, 255, 0);
            _pixels[4] = new Pixel(255, 255, 0, 0);
            _pixels[5] = new Pixel(255, 0, 255, 0);
            _pixels[6] = new Pixel(255, 0, 0, 255);
            _pixels[7] = new Pixel(255, 0, 255, 255);
            _pixels[8] = new Pixel(255, 255, 0, 255);
        }

        public PictureBox ColorPreviewImage { get; set; }

        public Pixel CurrentColor
        {
            get
            {
                return _pixels[_index];
            }
            set
            {
                _pixels[_index] = value;
                RedrawColorPreview();
            }
        }

        public void Init()
        {
            DrawBorder(Color.Red);
            RedrawColorPreview();
        }

        internal void SetIndex(int index)
        {
            DrawBorder(Color.Transparent);
            _index = index - 1;
            DrawBorder(Color.Red);
            ColorPreviewImage.Image = _colors;
        }

        private void DrawBorder(Color borderColor)
        {
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    if (y > 2
                        && y < 17
                        && x > 2
                        && x < 17)
                        continue;

                    _colors.SetPixel(x + (_index * 20), y, borderColor);
                }
            }
        }

        private void RedrawColorPreview()
        {
            Color borderColor = Color.Red;
            for (int i = 0; i < TotalColors; i++)
            {
                Color color = PixelHelper.PixelColor(_pixels[i]);
                for (int x = 0; x < 16; x++)
                {
                    for (int y = 0; y < 16; y++)
                    {
                        _colors.SetPixel(x + (i * 20) + 2, y + 2, color);
                    }
                }
            }

            ColorPreviewImage.Image = _colors;
        }
    }
}
