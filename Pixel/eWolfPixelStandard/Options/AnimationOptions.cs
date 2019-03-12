using System;

namespace eWolfPixelStandard.Options
{
    [Serializable]
    public class AnimationOptions
    {
        public int Frames { get; set; }

        public BorderStyle BorderStyle = new BorderStyle();

        public AnimationOptions()
        {
            BorderStyle = BorderStyle.BlackBold;
        }
    }
}