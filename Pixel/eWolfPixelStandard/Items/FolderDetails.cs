using eWolfPixelStandard.Project;

namespace eWolfPixelStandard.Items
{
    public class FolderDetails : ItemsBase
    {
        public FolderDetails(string name, string path)
        {
            _itemTypes = ItemTypes.Folder;
            Name = name;
            Path = path;
        }
    }
}
