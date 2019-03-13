using eWolfPixelStandard.Data;
using eWolfPixelStandard.Interfaces;
using eWolfPixelStandard.Items;
using eWolfPixelStandard.Project;
using eWolfPixelStandard.Services;
using eWolfPixelUI.Helpers;
using System.Drawing;
using System.IO;

namespace eWolfPixelUI.Services
{
    public class ExportImages : IExportImage
    {
        public void Export(ItemsBase itemBase, PixelSet[,] pixelArray)
        {
            ISaveable saveable = itemBase as ISaveable;

            ProjectHolder ph = ServiceLocator.Instance.GetService<ProjectHolder>();

            string outputFileName = Path.Combine(ph.ProjectPath, saveable.GetFileName);
            string extension = Path.GetExtension(outputFileName);
            outputFileName = outputFileName.Replace(extension, string.Empty);

            int directions = 8;
            int frames = 4;

            for (int i = 0; i < directions; i++)
            {
                for (int j = 0; j < frames; j++)
                {
                    Bitmap image = CreateImage(pixelArray[i, j]);
                    string filename = $"{outputFileName}_{i}_{j}.png";
                    image.Save(filename);
                }
            }
        }

        private Bitmap CreateImage(PixelSet pixelSet)
        {
            Pixel[,] pixels = pixelSet.Pixels;

            Bitmap previewImage = new Bitmap(64, 64);

            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    Color col = PixelHelper.PixelColor(pixels[i, j]);

                    previewImage.SetPixel(i, j, col);
                }
            }
            return previewImage;
        }
    }
}
