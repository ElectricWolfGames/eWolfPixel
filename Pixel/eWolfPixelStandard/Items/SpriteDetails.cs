using eWolfPixelStandard.Project;
using System;

namespace eWolfPixelStandard.Items
{
    [Serializable]
    public class SpriteDetails : ItemsBase
    {
        public SpriteDetails(string name, string path)
        {
            _itemTypes = ItemTypes.Sprite;
            Name = name;
            Path = path;
        }
    }
}
