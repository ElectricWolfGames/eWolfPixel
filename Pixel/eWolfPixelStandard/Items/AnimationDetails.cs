using eWolfPixelStandard.Data;
using eWolfPixelStandard.Helpers;
using eWolfPixelStandard.Interfaces;
using eWolfPixelStandard.Options;
using eWolfPixelStandard.Project;
using eWolfPixelStandard.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace eWolfPixelStandard.Items
{
    [Serializable]
    public class AnimationDetails : ItemsBase, IEditable, ISaveable
    {
        private AnimationOptions _animationOptions;
        private int _currentDirection = 0;
        private int _currentFrame = 0;
        private PixelSet[,] _pixelAnimations;

        public AnimationDetails(string name, string path)
        {
            ItemType = ItemTypes.Animation;
            Name = name;
            Path = path;
        }

        public AnimationOptions AnimationOptions { get => _animationOptions; set => _animationOptions = value; }
        public int CurrentFrame { get => _currentFrame; set => _currentFrame = value; }
        public int Direction { get => _currentDirection; set => _currentDirection = value; }
        public IFrameSize FrameSize { get => _animationOptions; }

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

        public override MenuItem[] CreateContextMenu()
        {
            List<MenuItem> itemToAdd = new List<MenuItem>();
            itemToAdd.Add(new MenuItem("Clear All frames", ClearItem));
            return itemToAdd.ToArray();
        }

        public Pixel GetColor(Point pixelPoint)
        {
            return PixelSetAnim.GetPixel(pixelPoint.X, pixelPoint.Y);
        }

        public override void PostLoadFix()
        {
            _currentFrame = 0;
            ItemType = ItemTypes.Animation;

            if (_animationOptions == null)
            {
                _animationOptions = new AnimationOptions();
            }

            _animationOptions.SetParent(this);

            if (_animationOptions.Frames == 0)
                _animationOptions.Frames = 4;

            if (_animationOptions.FrameWidth == 0)
                _animationOptions.FrameWidth = 24;

            if (_animationOptions.FrameHeight == 0)
                _animationOptions.FrameHeight = 24;

            if (_pixelAnimations == null)
            {
                _pixelAnimations = new PixelSet[8, 4];
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        _pixelAnimations[i, j] = new PixelSet(_animationOptions.FrameWidth, _animationOptions.FrameHeight);
                    }
                }
            }
            else
            {
                Rebuild();
            }
        }

        public void Rebuild()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < _animationOptions.Frames; j++)
                {
                    if (_pixelAnimations[i, j] != null)
                    {
                        _pixelAnimations[i, j].Rebuild(_animationOptions.FrameWidth, _animationOptions.FrameHeight);
                    }
                }
            }
        }

        public void Save(string projectPath)
        {
            ItemType = ItemTypes.Animation;
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
            ItemsBase item = ph.LoadDataSingle(filename);
            item.PostLoadFix();
            item.FullPath = filename;

            return item;
        }

        private void ClearItem(object sender, EventArgs e)
        {
            _pixelAnimations = null;
            PostLoadFix();
        }

        private void ExportImages()
        {
            IExportImage exportIamge = ServiceLocator.Instance.GetService<IExportImage>();
            if (exportIamge != null)
                exportIamge.Export(this, _pixelAnimations);
        }

        private void UpdateImage(int x, int y)
        {
            BorderHelper.Apply(_animationOptions.BorderStyle, PixelSetAnim);
        }
    }
}
