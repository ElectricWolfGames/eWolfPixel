using eWolfPixelStandard.Project;

namespace eWolfPixelStandard.Items
{
    public class FolderDetails : ItemsBase
    {
        public FolderDetails(string name, string path)
        {
            ItemType = ItemTypes.Folder;
            Name = name;
            Path = path;
        }
    }
}
