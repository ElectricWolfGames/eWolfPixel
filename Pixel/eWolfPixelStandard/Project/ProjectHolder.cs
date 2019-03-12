using eWolfPixelStandard.Helpers;
using eWolfPixelStandard.Interfaces;
using eWolfPixelStandard.Items;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("eWolfPixelStandard.UnitTests")]

namespace eWolfPixelStandard.Project
{
    public class ProjectHolder
    {
        private string _projectPath;

        public ProjectHolder()
        {
            Items = new List<ItemsBase>();
        }

        public List<ItemsBase> Items
        {
            get;
            private set;
        }

        public string ProjectPath
        {
            get
            {
                return _projectPath;
            }
        }

        public void CreateAnimation(string name, string path)
        {
            AnimationDetails ad = new AnimationDetails(name, path);
            Items.Add(ad);
            ad.Save(_projectPath);
        }

        public void CreateCharacter(string name, string path)
        {
            Items.Add(new FolderDetails(name, path));

            path = path.Replace("\\Root", string.Empty);
            string dir = Path.Combine(_projectPath, path, name);

            Directory.CreateDirectory(dir);
        }

        public void LoadProject(string projectPath)
        {
            _projectPath = projectPath;

            Items.Add(RootNode());

            List<string> files = FileHelper.GetAllDirectories(_projectPath);
            files.AddRange(FileHelper.GetAllFiles(_projectPath));
            foreach (string file in files)
            {
                string extension = Path.GetExtension(file);
                ItemTypes itemType = ItemHelper.GetType(extension);
                Items.Add(LoadItem(itemType, file));
            }
        }

        public ItemsBase RootNode()
        {
            return new FolderDetails("Root", string.Empty);
        }

        private ItemsBase LoadItem(ItemTypes itemType, string file)
        {
            if (itemType == ItemTypes.Folder)
            {
                string name = Path.GetFileName(file);
                string path = file.Replace(_projectPath, string.Empty);
                path = path.Replace(name, string.Empty);
                if (string.IsNullOrWhiteSpace(path))
                {
                    path = "\\Root";
                }

                return new FolderDetails(name, path);
            }

            if (itemType == ItemTypes.Animation)
            {
                return AnimationDetails.Load(_projectPath, file);
            }

            return null;
        }

        public void SaveProject()
        {
            foreach (ItemsBase item in Items)
            {
                ISaveable saveable = item as ISaveable;
                if (saveable != null)
                {
                    saveable.Save(_projectPath);
                }
            }
        }
    }
}
