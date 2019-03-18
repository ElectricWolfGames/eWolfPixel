using eWolfUnity3DParser.Sprites.Data;
using System;
using System.Collections.Generic;

namespace eWolfUnity3DParser.Sprites
{
    public class SpriteSheetData
    {
        public SpriteSheetData(SpriteSheetFileReader sfr)
        {
            FileFormatVersion = sfr.ReadLine().Replace("fileFormatVersion: ", string.Empty);
            FileGuid = sfr.ReadLine().Replace("guid: ", string.Empty);
            sfr.ReadLine();
            if (sfr.ReadLine().Contains("fileIDToRecycleName:"))
            {
                string line = sfr.ReadLine();
                while (!line.Contains("externalObjects"))
                {
                    string[] items = line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    NamesMap.Add(items[0].Trim(), items[1].Trim());

                    line = sfr.ReadLine();
                }
            }
            sfr.ReadUntil("  spriteSheet:");
            sfr.ReadLine();
            sfr.ReadLine();

            SpriteData sd = ReadSprite(sfr);
            SpritesMap.Add(sd.Name, sd);
        }

        private SpriteData ReadSprite(SpriteSheetFileReader sfr)
        {
            SpriteData sd = new SpriteData();

            sfr.ReadLine();
            // name: PL04_Left_Walk0
            sd.Name = sfr.ReadLine().Split(':')[1].Trim();
            sfr.ReadLine(); // rect:
            sfr.ReadLine(); // serializedVersion: 2
            sd.Rect.X = int.Parse(sfr.ReadLineSplitValue());
            sd.Rect.Y = int.Parse(sfr.ReadLineSplitValue());
            sd.Rect.Width = int.Parse(sfr.ReadLineSplitValue());
            sd.Rect.Height = int.Parse(sfr.ReadLineSplitValue());

            sfr.ReadLine(); //       alignment: 7
            sd.Pivot = ParsePivot(sfr.ReadLine()); //       pivot: {x: 0.5, y: 0}
            sfr.ReadLine(); //       border: {x: 0, y: 0, z: 0, w: 0}
            sfr.ReadLine(); //       outline: []
            sfr.ReadLine(); //       physicsShape: []
            sfr.ReadLine(); //       tessellationDetail: 0
            sfr.ReadLine(); //       bones: []
            sfr.ReadLine(); //       spriteID: 2f9a5b012f5af2747902bba879ef1838
            sfr.ReadLine(); //       vertices: []
            sfr.ReadLine(); //       indices:
            sfr.ReadLine(); //       edges: []
            sfr.ReadLine(); //       weights: []

            return sd;
        }

        private SpritePivot ParsePivot(string line)
        {
            SpritePivot pivot = new SpritePivot();
            // pivot: {x: 0.5, y: 0}
            string[] parts = line.Split(':');
            string x = parts[2].Replace(", y", string.Empty).Trim();
            string y = parts[3].Replace("}", string.Empty).Trim();
            pivot.X = float.Parse(x);
            pivot.Y = float.Parse(y);
            return pivot;
        }

        public string FileFormatVersion { get; set; }
        public string FileGuid { get; set; }

        public Dictionary<string, string> NamesMap = new Dictionary<string, string>();
        public Dictionary<string, SpriteData> SpritesMap = new Dictionary<string, SpriteData>();
    }
}
