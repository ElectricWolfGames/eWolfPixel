using System;
using eWolfPixelStandard.Data;
using eWolfPixelStandard.Project;
using eWolfPixelStandard.Helpers;
using eWolfPixelStandard.Interfaces;
using System.Drawing;
using eWolfPixelStandard.Options;

namespace eWolfPixelStandard.Items
{
    [Serializable]
    public class AnimationDetails : ItemsBase, IEditable
    {
        private AnimationOptions _animationOptions;

        private PixelSet _pixelSet;

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
                _pixelSet = new PixelSet(24, 24);

            _pixelSet.SetPixel(x, y, color);
            UpdateImage(x, y);
        }

        public void SetColor(Point pixelPoint, Pixel color)
        {
            if (_pixelSet == null)
                _pixelSet = new PixelSet(24, 24);

            _pixelSet.SetPixel(pixelPoint.X, pixelPoint.Y, color);
            UpdateImage(pixelPoint.X, pixelPoint.Y);
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

        private void UpdateImage(int x, int y)
        {
            if (_animationOptions == null)
                _animationOptions = new AnimationOptions();

            BorderHelper.Apply(_animationOptions.BorderStyle, _pixelSet);
        }
    }
}
