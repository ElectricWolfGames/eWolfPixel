using System;

namespace eWolfPixelStandard.Options
{
    [Serializable]
    public class AnimationOptions
    {
        public AnimationOptions()
        {
            BorderStyle = BorderStyle.Black;
        }

        public BorderStyle BorderStyle { get; set; }
        public int Frames { get; set; }
    }
}
