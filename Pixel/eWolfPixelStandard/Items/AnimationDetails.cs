using eWolfPixelStandard.Data;
using eWolfPixelStandard.Helpers;
using eWolfPixelStandard.Interfaces;
using eWolfPixelStandard.Options;
using eWolfPixelStandard.Project;
using eWolfPixelStandard.Services;
using System;
using System.Drawing;

namespace eWolfPixelStandard.Items
{
    [Serializable]
    public class AnimationDetails : ItemsBase, IEditable, ISaveable
    {
        private AnimationOptions _animationOptions;
        private PixelSet[,] _pixelAnimations;
        private int _currentDirection = 0;
        private int _currentFrame = 0;

        public AnimationDetails(string name, string path)
        {
            _itemTypes = ItemTypes.Animation;
            Name = name;
            Path = path;
        }

        public int CurrentFrame { get => _currentFrame; set => _currentFrame = value; }

        public int Direction { get => _currentDirection; set => _currentDirection = value; }

        public AnimationOptions AnimationOptions { get => _animationOptions; set => _animationOptions = value; }

        public Pixel[,] PixelArray
        {
            get
            {
                return _pixelAnimations[_currentDirection, _currentFrame].Pixels;
            }
        }

        public PixelSet PixelSetAnim
        {
            get
            {
                return _pixelAnimations[_currentDirection, _currentFrame];
            }
        }

        public override void PostLoadFix()
        {
            _itemTypes = ItemTypes.Animation;

            if (_pixelAnimations == null)
            {
                _pixelAnimations = new PixelSet[8, 4];
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        _pixelAnimations[i, j] = new PixelSet(24, 24);
                    }
                }
            }
        }

        public void Save(string projectPath)
        {
            _itemTypes = ItemTypes.Animation;
            PersistenceHelper<AnimationDetails> ph = new PersistenceHelper<AnimationDetails>(projectPath);
            ph.SaveDataSingle(this);

            ExportImages();
        }

        public void SetColor(int x, int y, Pixel color)
        {
            PixelSetAnim.SetPixel(x, y, color);
            UpdateImage(x, y);
        }

        public void SetColor(Point pixelPoint, Pixel color)
        {
            PixelSetAnim.SetPixel(pixelPoint.X, pixelPoint.Y, color);
            UpdateImage(pixelPoint.X, pixelPoint.Y);
        }

        internal static ItemsBase Load(string projectPath, string filename)
        {
            PersistenceHelper<AnimationDetails> ph = new PersistenceHelper<AnimationDetails>(projectPath);
            return ph.LoadDataSingle(filename);
        }

        private void ExportImages()
        {
            IExportImage exportIamge = ServiceLocator.Instance.GetService<IExportImage>();
            if (exportIamge != null)
                exportIamge.Export(this, _pixelAnimations);
        }

        private void UpdateImage(int x, int y)
        {
            if (_animationOptions == null)
                _animationOptions = new AnimationOptions();

            BorderHelper.Apply(_animationOptions.BorderStyle, PixelSetAnim);
        }
    }
}
