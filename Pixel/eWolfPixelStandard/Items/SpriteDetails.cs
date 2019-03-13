using eWolfPixelStandard.Project;
using System;

namespace eWolfPixelStandard.Items
{
    [Serializable]
    public class SpriteDetails : ItemsBase
    {
        public SpriteDetails(string name, string path)
        {
            ItemType = ItemTypes.Sprite;
            Name = name;
            Path = path;
        }
    }
}
