using System.Windows.Forms;

namespace eWolfPixelUI.ImageEditor
{
    public class AnimationPreview
    {
        private readonly PictureBox _animImage;
        private readonly ImageEditor _imageEditor;

        public AnimationPreview(ImageEditor imageEditor, PictureBox animImage)
        {
            _imageEditor = imageEditor;
            _animImage = animImage;
        }

        public int Delay { get; set; } = 10;
        public int Frame { get; set; } = 0;

        public void Tick()
        {
            if (Delay-- == 0)
            {
                Frame++;
                if (Frame == 4)
                {
                    Frame = 0;
                }
                _animImage.Image = _imageEditor.GetFrame(0, Frame);
                Delay = 10;
            }
        }
    }
}
