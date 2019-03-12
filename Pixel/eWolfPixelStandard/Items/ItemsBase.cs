using System;
using eWolfPixelStandard.Interfaces;
using eWolfPixelStandard.Project;
using eWolfPixelStandard.Helpers;
using System.Drawing;

namespace eWolfPixelStandard.Items
{
    [Serializable]
    public abstract class ItemsBase : ISaveable
    {
        protected string _name;
        protected string _path;

        protected ItemTypes _itemTypes = ItemTypes.None;

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Path
        {
            get
            {
                return _path;
            }
        }

        public string FullPath
        {
            get
            {
                return _path + "\\" + _name;
            }
        }

        public string GetFileName
        {
            get
            {
                string path = $"{FullPath.TrimStart('\\')}.{ItemHelper.GetType(_itemTypes)}";
                path = path.Replace("Root\\", string.Empty);
                return path;
            }
        }

        public bool IsFolder
        {
            get
            {
                return _itemTypes == ItemTypes.Folder;
            }
        }
    }
}
