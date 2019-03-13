using eWolfPixelStandard.Interfaces;
using eWolfPixelStandard.Items;
using eWolfPixelStandard.Project;
using eWolfPixelStandard.Services;
using eWolfPixelUI.ImageEditor;
using eWolfPixelUI.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace eWolfPixelCoreUI
{
    public partial class Form1 : Form
    {
        private AnimationPreview _animationPreview;
        private ImageEditor _imageEditor = new ImageEditor();
        private ProjectHolder _projectHolder = new ProjectHolder();

        public Form1()
        {
            InitializeComponent();
            _projectHolder.LoadProject(@"C:\GitHub\eWolfPixel\Pixel\DummyTestProject\");

            InitializeServices();

            PopulateTree();

            _imageEditor.EditImage = _editImage;
            _imageEditor.PreviewImage = _previewImage;
            _animationPreview = new AnimationPreview(_imageEditor, _animImage);

            CreateAnimationTimer();
        }

        private Timer TimeInterval { get; set; }

        protected void _projectView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            OpenItem(e);
        }

        private void _editImage_Click(object sender, EventArgs e)
        {
            Point localMousePosition = _editImage.PointToClient(Cursor.Position);
            _imageEditor.ClickImage(localMousePosition);
        }

        private void _editImage_MouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            Point localMousePosition = _editImage.PointToClient(Cursor.Position);
            _imageEditor.MoveInImage(localMousePosition, mouseEventArgs);
        }

        private void _projectView_MouseClick(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button == MouseButtons.Right)
            {
                MenuItem[] itemToAdd = new MenuItem[3];
                itemToAdd[0] = new MenuItem("Character", AddCharacter);
                itemToAdd[1] = new MenuItem("Animation", AddAnimation);
                itemToAdd[2] = new MenuItem("Sprite");

                ContextMenu cm = new ContextMenu();
                cm.MenuItems.Add("Add", itemToAdd);

                _projectView.ContextMenu = cm;
            }
        }

        private void AddAnimation(object sender, EventArgs e)
        {
            _projectHolder.CreateAnimation("Walk", "\\Root\\Char1");
            PopulateTree();
        }

        private void AddCharacter(object sender, EventArgs e)
        {
            _projectHolder.CreateCharacter("Char1", "\\Root");

            PopulateTree();
        }

        private void CreateAnimationTimer()
        {
            TimeInterval = new Timer
            {
                Interval = 25
            };
            TimeInterval.Start();
            TimeInterval.Tick += new EventHandler(TimerTick);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            _imageEditor.KeyPressed(e);
        }

        private void InitializeServices()
        {
            ServiceLocator.Instance.InjectService<IExportImage>(new ExportImages());
            ServiceLocator.Instance.InjectService<ProjectHolder>(_projectHolder);
        }

        private void MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int wheelDelta = e.Delta / 120;
            Point localMousePosition = _editImage.PointToClient(Cursor.Position);
            _imageEditor.MoveWheelImage(localMousePosition, wheelDelta);
        }

        private void OpenItem(TreeViewEventArgs e)
        {
            if (e.Node.Text == "Walk")
            {
                ItemsBase itemBase = e.Node.Tag as ItemsBase;
                // _imageEditor.ShowImage();
            }
        }

        private void PopulateTree()
        {
            _projectView.Nodes.Clear();
            List<ItemsBase> items = _projectHolder.Items;

            // preselect item
            foreach (ItemsBase item in items)
            {
                if (item == null)
                    continue;

                item.PostLoadFix();

                if (item.Name == "Walk")
                {
                    IEditable editable = item as IEditable;
                    if (editable != null)
                    {
                        SetEditItem(editable);
                    }
                }
            }

            Dictionary<string, TreeNode> nodeMap = new Dictionary<string, TreeNode>();

            foreach (ItemsBase item in items)
            {
                if (item == null)
                    continue;

                TreeNode tn = new TreeNode(item.Name);
                tn.Tag = item;
                if (nodeMap.TryGetValue(item.Path, out TreeNode parent))
                {
                    parent.Nodes.Add(tn);
                    if (item.IsFolder)
                    {
                        nodeMap.Add(item.FullPath, tn);
                    }
                }
                else
                {
                    nodeMap.Add(item.FullPath, tn);
                    _projectView.Nodes.Add(tn);
                }
            }
            _projectView.ExpandAll();
        }

        private void SaveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _projectHolder.SaveProject();
        }

        private void SetEditItem(IEditable item)
        {
            _imageEditor.SetItem(item);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            _animationPreview.Tick();
        }
    }
}
