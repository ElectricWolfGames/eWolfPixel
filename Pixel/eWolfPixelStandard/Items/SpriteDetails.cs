using System;
using eWolfPixelStandard.Project;

namespace eWolfPixelStandard.Items
{
    [Serializable]
    public class SpriteDetails : ItemsBase
    {
        public SpriteDetails(string name, string path)
        {
            _itemTypes = ItemTypes.Sprite;
            _name = name;
            _path = path;
        }
    }
}
