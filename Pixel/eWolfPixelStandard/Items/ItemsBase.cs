using eWolfPixelStandard.Helpers;
using eWolfPixelStandard.Project;
using System;

namespace eWolfPixelStandard.Items
{
    [Serializable]
    public abstract class ItemsBase
    {
        private string _name;
        private string _path;

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

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
            }
        }

        protected ItemTypes _itemTypes { get; set; }

        public virtual void PostLoadFix()
        {
        }
    }
}
