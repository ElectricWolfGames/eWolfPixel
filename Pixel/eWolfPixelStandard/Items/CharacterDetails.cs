using eWolfPixelStandard.Data;
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
            string filename = @"C:\GitHub\eWolfPixel\Pixel\eWolfUnity3DParser.UnitTests\TestingData\Player04.png";
            SpriteSheetData spriteSheetData = SpriteParser.ParseLoad(filename + ".meta");
            // spin up a bitmap reader to read the image and create pixelSets for each sprite.
            PixelSet image = ServiceLocator.Instance.GetService<IPixelLoader>().LoadImage(filename);
            Dictionary<string, PixelSet> frames = image.CutFrames(spriteSheetData);

            ProjectHolder projectHolder = ServiceLocator.Instance.GetService<ProjectHolder>();
            AnimationDetails ad = new AnimationDetails($"Walk", "\\Root\\Char1");
            projectHolder.Items.Add(ad);
            ad.PostLoadFix();

            // PL04_DownLeft_Walk0

            List<PixelSet> leftWalk = new List<PixelSet>();
            leftWalk.Add(frames["PL04_Left_Walk0"]);
            leftWalk.Add(frames["PL04_Left_Walk1"]);
            leftWalk.Add(frames["PL04_Left_Walk0"]);
            leftWalk.Add(frames["PL04_Left_Walk2"]);
            AddFrameToAnim(0, ad, leftWalk);

            List<PixelSet> downLeftWalk = new List<PixelSet>();
            downLeftWalk.Add(frames["PL04_DownLeft_Walk0"]);
            downLeftWalk.Add(frames["PL04_DownLeft_Walk1"]);
            downLeftWalk.Add(frames["PL04_DownLeft_Walk0"]);
            downLeftWalk.Add(frames["PL04_DownLeft_Walk2"]);
            AddFrameToAnim(1, ad, downLeftWalk);

            List<PixelSet> rightWalk = new List<PixelSet>();
            rightWalk.Add(frames["PL04_Right_Walk0"]);
            rightWalk.Add(frames["PL04_Right_Walk1"]);
            rightWalk.Add(frames["PL04_Right_Walk0"]);
            rightWalk.Add(frames["PL04_Right_Walk2"]);
            AddFrameToAnim(2, ad, rightWalk);

            ad.Save(projectHolder.ProjectPath);
        }

        private static void AddFrameToAnim(int direction, AnimationDetails ad, List<PixelSet> leftWalk)
        {
            int index = 0;
            foreach (var frame in leftWalk)
            {
                ad.SetAnimFrame(direction, index++, frame);
            }
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
