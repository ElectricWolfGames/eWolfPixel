namespace eWolfUnity3DParser.Sprites
{
    public class SpriteParser
    {
        public static SpriteSheetData Parse(string rawfile)
        {
            SpriteSheetFileReader sfr = new SpriteSheetFileReader(rawfile);
            SpriteSheetData sd = new SpriteSheetData(sfr);

            return sd;
        }

        public static SpriteSheetData ParseLoad(string fileName)
        {
            string raw = System.IO.File.ReadAllText(fileName);
            return Parse(raw);
        }
    }
}
