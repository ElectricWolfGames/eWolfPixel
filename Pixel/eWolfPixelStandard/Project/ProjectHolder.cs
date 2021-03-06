﻿using eWolfPixelStandard.Helpers;
using eWolfPixelStandard.Interfaces;
using eWolfPixelStandard.Items;
using eWolfPixelStandard.Services;
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
            ad.PostLoadFix();
            ad.Save(_projectPath);
        }

        public void CreateCharacter(string name, string path)
        {
            Items.Add(new CharacterDetails(name, path));

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

        internal static void AddAnimation(ItemsBase root)
        {
            IEditNameUI editNameUI = ServiceLocator.Instance.GetService<IEditNameUI>();
            string name = editNameUI.EditName("Animation", "Name");

            ProjectHolder projectHolder = ServiceLocator.Instance.GetService<ProjectHolder>();
            projectHolder.CreateAnimation(name, root.FullPath);
            ServiceLocator.Instance.GetService<IMainUI>().PopulateTree();
        }

        internal static void AddCharactor(ItemsBase root)
        {
            IEditNameUI editNameUI = ServiceLocator.Instance.GetService<IEditNameUI>();
            string name = editNameUI.EditName("Charactor", "Name");

            ProjectHolder projectHolder = ServiceLocator.Instance.GetService<ProjectHolder>();
            projectHolder.CreateCharacter(name, root.FullPath);
            ServiceLocator.Instance.GetService<IMainUI>().PopulateTree();
        }

        private bool AnyAnimsInFolder(string filepath)
        {
            if (Path.HasExtension(filepath))
                return false;

            List<string> files = FileHelper.GetAllFiles(filepath);
            foreach (string file in files)
            {
                if (Path.GetExtension(file).ToUpper() == ".ANIM")
                {
                    return true;
                }
            }
            return false;
        }

        private ItemsBase LoadItem(ItemTypes itemType, string file)
        {
            if (AnyAnimsInFolder(file))
            {
                string name = Path.GetFileName(file);
                string path = file.Replace(_projectPath, string.Empty);
                path = path.Replace(name, string.Empty);
                if (string.IsNullOrWhiteSpace(path))
                {
                    path = "\\Root";
                }

                return new CharacterDetails(name, path);
            }

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
    }
}
