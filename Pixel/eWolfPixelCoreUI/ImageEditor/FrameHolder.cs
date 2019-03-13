using System.Drawing;

namespace eWolfPixelUI.ImageEditor
{
    public class FrameHolder
    {
        private Color[,] _color;
        private Bitmap _image;
        private Bitmap _previewImage;

        public Color[,] Color
        {
            get
            {
                if (_color == null)
                {
                    _color = new Color[24, 24];
                }
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public Bitmap Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
            }
        }

        public Bitmap PreviewImage
        {
            get
            {
                return _previewImage;
            }
            set
            {
                _previewImage = value;
            }
        }
    }
}
