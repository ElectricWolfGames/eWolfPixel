using eWolfPixelStandard.Data;

namespace eWolfPixelStandard.Interfaces
{
    public interface IPixelLoader
    {
        PixelSet LoadImage(string filename);
    }
}
