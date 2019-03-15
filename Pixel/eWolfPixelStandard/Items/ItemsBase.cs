using eWolfPixelStandard.Helpers;
using eWolfPixelStandard.Project;
using System;
using System.Windows.Forms;

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

            set
            {
                string file = value;
                string[] parts = file.Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

                string name = parts[parts.Length - 1].Replace($".{ItemHelper.GetType(ItemType)}", string.Empty);
                _name = name;
                _path = "\\Root\\" + parts[parts.Length - 2];
            }
        }

        public string GetFileName
        {
            get
            {
                string path = $"{FullPath.TrimStart('\\')}.{ItemHelper.GetType(ItemType)}";
                path = path.Replace("Root\\", string.Empty);
                return path;
            }
        }

        public bool IsFolder
        {
            get
            {
                return ItemType == ItemTypes.Folder || ItemType == ItemTypes.Character;
            }
        }

        public ItemTypes ItemType { get; protected set; }

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

        public virtual void Clear()
        {
        }

        public virtual MenuItem[] CreateContextMenu()
        {
            return new MenuItem[0];
        }

        public virtual void PostLoadFix()
        {
        }
    }
}
