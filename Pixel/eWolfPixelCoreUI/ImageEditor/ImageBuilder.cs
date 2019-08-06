using System;
using System.Drawing;
using System.Drawing.Imaging;
using eWolfPixelStandard.Data;
using eWolfPixelStandard.Interfaces;
using eWolfPixelUI.Helpers;

namespace eWolfPixelUI.ImageEditor
{
    public static class ImageBuilder
    {
        internal static void UpdateImage(
            FrameHolder frameHolder,
            IEditable itemsBase,
            Pixel[,] pixels,
            ImageEditor imageEditor)
        {
            BitmapData data = frameHolder.Image.LockBits(
                new Rectangle(0, 0, frameHolder.Image.Width, frameHolder.Image.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = data.Stride;
            unsafe
            {
                for (int i = 0; i < itemsBase.FrameSize.FrameWidth; i++)
                {
                    for (int j = 0; j < itemsBase.FrameSize.FrameHeight; j++)
                    {
                        Color col = PixelHelper.PixelColor(pixels[i, j]);

                        if (frameHolder.Color[i, j] != col)
                        {
                            frameHolder.PreviewImage.SetPixel(i, j, col);
                            frameHolder.Color[i, j] = col;
                            imageEditor.DrawScaledPixel(i, j, col);
                        }
                    }
                }
            }
            frameHolder.Image.UnlockBits(data);
        }
    }
}