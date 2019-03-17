namespace eWolfUnity3DParser.Sprites
{
    public class SpriteSheetFileReader
    {
        private readonly string[] _lines;
        private int _index = 0;

        public SpriteSheetFileReader(string rawfile)
        {
            _lines = rawfile.Split('\n');
        }

        public string ReadLine()
        {
            return _lines[_index++];
        }
    }
}
