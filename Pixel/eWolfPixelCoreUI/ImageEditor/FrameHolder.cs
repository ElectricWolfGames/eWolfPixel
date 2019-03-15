using eWolfPixelStandard.Interfaces;
using System;
using System.Drawing;

namespace eWolfPixelUI.ImageEditor
{
    public class FrameHolder
    {
        private Color[,] _color;
        private int _frameHeight;
        private int _frameWidth;
        private Bitmap _image;
        private Bitmap _previewImage;

        public FrameHolder(IFrameSize frameSize)
        {
            _frameWidth = frameSize.FrameWidth;
            _frameHeight = frameSize.FrameHeight;
        }

        public Color[,] Color
        {
            get
            {
                if (_color == null)
                {
                    _color = new Color[_frameWidth, _frameHeight];
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

        internal void Check(IFrameSize frameSize)
        {
            if (_frameWidth == frameSize.FrameWidth
                && _frameHeight == frameSize.FrameHeight)
            {
                return;
            }

            _frameWidth = frameSize.FrameWidth;
            _frameHeight = frameSize.FrameHeight;

            _color = new Color[_frameWidth, _frameHeight];
            Image = null;
            PreviewImage = null;
        }
    }
}
