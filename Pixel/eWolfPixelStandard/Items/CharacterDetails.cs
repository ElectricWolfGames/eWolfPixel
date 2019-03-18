using eWolfPixelStandard.Interfaces;
using eWolfPixelStandard.Project;
using eWolfPixelStandard.Services;
using eWolfUnity3DParser.Sprites;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace eWolfPixelStandard.Items
{
    [Serializable]
    public class CharacterDetails : ItemsBase
    {
        public CharacterDetails(string name, string path)
        {
            ItemType = ItemTypes.Character;
            Name = name;
            Path = path;
        }

        public override MenuItem[] CreateContextMenu()
        {
            List<MenuItem> itemToAdd = new List<MenuItem>
            {
                new MenuItem("Character", AddCharacter),
                new MenuItem("Animation", AddAnimation),
                new MenuItem("Sprite"),
            };

            List<MenuItem> inportOptions = new List<MenuItem>
            {
                new MenuItem("InportFromUnity", InportFromUnity)
            };

            return new MenuItem[2] {
                new MenuItem("Add", itemToAdd.ToArray()),
                new MenuItem("Inport", inportOptions .ToArray())
            };
        }

        private void InportFromUnity(object sender, EventArgs e)
        {
            SpriteSheetData spriteSheetData = SpriteParser.Parse("Test file");
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
