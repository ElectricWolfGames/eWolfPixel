using eWolfPixelStandard.Data;
using eWolfPixelStandard.Helpers;
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
            AddFrameToAnim(Directions8Way.Left, ad, leftWalk);

            List<PixelSet> downLeftWalk = new List<PixelSet>();
            downLeftWalk.Add(frames["PL04_DownLeft_Walk0"]);
            downLeftWalk.Add(frames["PL04_DownLeft_Walk1"]);
            downLeftWalk.Add(frames["PL04_DownLeft_Walk0"]);
            downLeftWalk.Add(frames["PL04_DownLeft_Walk2"]);
            AddFrameToAnim(Directions8Way.DownLeft, ad, downLeftWalk);

            List<PixelSet> downRightWalk = new List<PixelSet>();
            downRightWalk.Add(frames["PL04_DownRight_Walk0"]);
            downRightWalk.Add(frames["PL04_DownRight_Walk1"]);
            downRightWalk.Add(frames["PL04_DownRight_Walk0"]);
            downRightWalk.Add(frames["PL04_DownRight_Walk2"]);
            AddFrameToAnim(Directions8Way.DownRight, ad, downRightWalk);

            List<PixelSet> rightWalk = new List<PixelSet>();
            rightWalk.Add(frames["PL04_Right_Walk0"]);
            rightWalk.Add(frames["PL04_Right_Walk1"]);
            rightWalk.Add(frames["PL04_Right_Walk0"]);
            rightWalk.Add(frames["PL04_Right_Walk2"]);
            AddFrameToAnim(Directions8Way.Right, ad, rightWalk);

            List<PixelSet> upLeftWalk = new List<PixelSet>();
            upLeftWalk.Add(frames["PL04_UpLeft_Walk0"]);
            upLeftWalk.Add(frames["PL04_UpLeft_Walk1"]);
            upLeftWalk.Add(frames["PL04_UpLeft_Walk0"]);
            upLeftWalk.Add(frames["PL04_UpLeft_Walk2"]);
            AddFrameToAnim(Directions8Way.UpLeft, ad, upLeftWalk);

            List<PixelSet> upWalk = new List<PixelSet>();
            upWalk.Add(frames["PL04_Up_Walk0"]);
            upWalk.Add(frames["PL04_Up_Walk1"]);
            upWalk.Add(frames["PL04_Up_Walk0"]);
            upWalk.Add(frames["PL04_Up_Walk2"]);
            AddFrameToAnim(Directions8Way.Up, ad, upWalk);

            List<PixelSet> downWalk = new List<PixelSet>();
            downWalk.Add(frames["PL04_Down_Walk0"]);
            downWalk.Add(frames["PL04_Down_Walk1"]);
            downWalk.Add(frames["PL04_Down_Walk0"]);
            downWalk.Add(frames["PL04_Down_Walk2"]);
            AddFrameToAnim(Directions8Way.Down, ad, downWalk);

            List<PixelSet> upRightWalk = new List<PixelSet>();
            upRightWalk.Add(frames["PL04_UpRight_Walk0"]);
            upRightWalk.Add(frames["PL04_UpRight_Walk1"]);
            upRightWalk.Add(frames["PL04_UpRight_Walk0"]);
            upRightWalk.Add(frames["PL04_UpRight_Walk2"]);
            AddFrameToAnim(Directions8Way.UpRight, ad, upRightWalk);

            ad.Save(projectHolder.ProjectPath);
        }

        private static void AddFrameToAnim(Directions8Way direction, AnimationDetails ad, List<PixelSet> leftWalk)
        {
            int dir = Directions8WayHelper.GetDirectionIndex(direction);
            int index = 0;
            foreach (var frame in leftWalk)
            {
                ad.SetAnimFrame(dir, index++, frame);
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
