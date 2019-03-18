using System;

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

        public string ReadLineSplitKey()
        {
            string pair = _lines[_index++];
            string[] parts = pair.Split(':');
            return parts[0].Trim();
        }

        public string ReadLineSplitValue()
        {
            string pair = _lines[_index++];
            string[] parts = pair.Split(':');
            return parts[1].Trim();
        }

        public void ReadUntil(string textToFind)
        {
            while (_lines[_index++] != textToFind)
            {
            }
        }
    }
}
