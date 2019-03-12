using eWolfPixelStandard.Data;
using eWolfPixelStandard.Helpers;
using eWolfPixelStandard.Interfaces;
using eWolfPixelStandard.Options;
using eWolfPixelStandard.Project;
using System;
using System.Drawing;

namespace eWolfPixelStandard.Items
{
    [Serializable]
    public class AnimationDetails : ItemsBase, IEditable, ISaveable
    {
        private AnimationOptions _animationOptions;

        private PixelSet _pixelSet;

        public AnimationDetails(string name, string path)
        {
            _itemTypes = ItemTypes.Animation;
            Name = name;
            Path = path;
        }

        public AnimationOptions AnimationOptions { get => _animationOptions; set => _animationOptions = value; }

        public Pixel[,] PixelArray
        {
            get
            {
                return _pixelSet.Pixels;
            }
        }

        public PixelSet PixelSet { get => _pixelSet; set => _pixelSet = value; }

        public void Save(string projectPath)
        {
            _itemTypes = ItemTypes.Animation;
            PersistenceHelper<AnimationDetails> ph = new PersistenceHelper<AnimationDetails>(projectPath);
            ph.SaveDataSingle(this);
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

        private void UpdateImage(int x, int y)
        {
            if (_animationOptions == null)
                _animationOptions = new AnimationOptions();

            BorderHelper.Apply(_animationOptions.BorderStyle, _pixelSet);
        }
    }
}
