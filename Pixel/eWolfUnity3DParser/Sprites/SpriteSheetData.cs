namespace eWolfUnity3DParser.Sprites
{
    public class SpriteSheetData
    {
        public SpriteSheetData(SpriteSheetFileReader sfr)
        {
            FileFormatVersion = sfr.ReadLine().Replace("fileFormatVersion: ", string.Empty);
            FileGuid = sfr.ReadLine().Replace("guid: ", string.Empty);
        }

        public string FileFormatVersion { get; set; }
        public string FileGuid { get; set; }
    }
}
