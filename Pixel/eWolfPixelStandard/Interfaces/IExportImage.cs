using eWolfPixelStandard.Data;
using eWolfPixelStandard.Items;

namespace eWolfPixelStandard.Interfaces
{
    public interface IExportImage
    {
        void Export(ItemsBase itemBase, PixelSet[,] pixelArray);
    }
}
