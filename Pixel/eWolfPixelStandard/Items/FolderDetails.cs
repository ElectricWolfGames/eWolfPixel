﻿using eWolfPixelStandard.Interfaces;
using eWolfPixelStandard.Project;
using eWolfPixelStandard.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

        public override MenuItem[] CreateContextMenu()
        {
            List<MenuItem> itemToAdd = new List<MenuItem>
            {
                new MenuItem("Character", AddCharacter),
                new MenuItem("Animation", AddAnimation)
            };

            return new MenuItem[1] { new MenuItem("Add", itemToAdd.ToArray()) };
        }

        private void AddAnimation(object sender, EventArgs e)
        {
            ProjectHolder projectHolder = ServiceLocator.Instance.GetService<ProjectHolder>();
            projectHolder.CreateAnimation("Walk", "\\Root\\Char1");
            ServiceLocator.Instance.GetService<IMainUI>().PopulateTree();
        }

        private void AddCharacter(object sender, EventArgs e)
        {
            ProjectHolder projectHolder = ServiceLocator.Instance.GetService<ProjectHolder>();
            projectHolder.CreateCharacter("Char1", "\\Root");
            ServiceLocator.Instance.GetService<IMainUI>().PopulateTree();
        }
    }
}
