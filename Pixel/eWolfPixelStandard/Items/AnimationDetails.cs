using System;
using eWolfPixelStandard.Data;
using eWolfPixelStandard.Project;
using eWolfPixelStandard.Helpers;
using eWolfPixelStandard.Interfaces;
using System.Drawing;

namespace eWolfPixelStandard.Items
{
    [Serializable]
    public class AnimationDetails : ItemsBase, IEditable
    {
        private PixelSet _pixelSet = new PixelSet();

        public AnimationDetails(string name, string path)
        {
            _itemTypes = ItemTypes.Animation;
            _name = name;
            _path = path;
        }

        public Pixel[,] PixelArray
        {
            get
            {
                return _pixelSet.Pixels;
            }
        }

        public void SetColor(int x, int y, Pixel color)
        {
            if (_pixelSet == null)
                _pixelSet = new PixelSet();

            _pixelSet.SetPixel(x, y, color);
        }

        internal static ItemsBase Load(string projectPath, string filename)
        {
            PersistenceHelper<AnimationDetails> ph = new PersistenceHelper<AnimationDetails>(projectPath);
            return ph.LoadDataSingle(filename);
        }

        internal void Save(string projectPath)
        {
            PersistenceHelper<AnimationDetails> ph = new PersistenceHelper<AnimationDetails>(projectPath);
            ph.SaveDataSingle(this);
        }
    }
}
