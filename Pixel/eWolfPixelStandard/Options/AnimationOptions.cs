using System;
using eWolfPixelStandard.Interfaces;
using eWolfPixelStandard.Items;

namespace eWolfPixelStandard.Options
{
    [Serializable]
    public class AnimationOptions : IFrameSize
    {
        private AnimationDetails _animationDetails;
        private int _frameHeight = 32;
        private int _frameWidth = 24;

        public AnimationOptions()
        {
            BorderStyle = BorderStyle.Black;
        }

        public BorderStyle BorderStyle { get; set; }

        public int FrameHeight
        {
            get
            {
                return _frameHeight;
            }
            set
            {
                if (_frameHeight != value)
                {
                    _frameHeight = value;
                    _animationDetails.Rebuild();
                }
            }
        }

        public int Frames { get; set; } = 4;

        public int FrameWidth
        {
            get
            {
                return _frameWidth;
            }
            set
            {
                if (_frameWidth != value)
                {
                    _frameWidth = value;
                    _animationDetails.Rebuild();
                }
            }
        }

        internal void SetParent(AnimationDetails animationDetails)
        {
            _animationDetails = animationDetails;
        }
    }
}
