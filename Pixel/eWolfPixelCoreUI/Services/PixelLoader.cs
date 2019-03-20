using eWolfPixelStandard.Data;
using eWolfPixelStandard.Interfaces;
using eWolfPixelUI.Helpers;
using System.Drawing;

namespace eWolfPixelUI.Services
{
    public class PixelLoader : IPixelLoader
    {
        public PixelSet LoadImage(string filename)
        {
            Image loadImage = Image.FromFile(filename);
            Bitmap bitmap = new Bitmap(loadImage);

            PixelSet pixelSet = new PixelSet(loadImage.Width, loadImage.Height);

            for (int i = 0; i < loadImage.Width - 1; i++)
            {
                for (int j = 0; j < loadImage.Height - 1; j++)
                {
                    pixelSet.Pixels[i, j] = PixelHelper.Create(bitmap.GetPixel(i, j));
                }
            }
            return pixelSet;
        }
    }
}
