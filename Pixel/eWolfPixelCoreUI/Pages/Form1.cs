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
    public partial class Form1 : Form, IMainUI
    {
        private AnimationPreview _animationPreview;
        private ImageEditor _imageEditor = new ImageEditor();
        private ProjectHolder _projectHolder = new ProjectHolder();
        private ItemsBase _selectedItem;
        private ItemsBase _clickedOnItem = null;

        public Form1()
        {
            InitializeComponent();
            _projectHolder.LoadProject(@"C:\GitHub\eWolfPixel\Pixel\DummyTestProject\");

            _imageEditor.EditImage = _editImage;
            _imageEditor.PreviewImage = _previewImage;
            _imageEditor.ColorImage = _pictureColors;
            _imageEditor.ColorPreviewImage = _ColorPreviewPictureBox;

            InitializeServices();

            PopulateTree();

            _animationPreview = new AnimationPreview(_imageEditor, _animImage);

            CreateAnimationTimer();
        }

        private Timer TimeInterval { get; set; }

        public void PopulateTree()
        {
            _projectView.Nodes.Clear();
            List<ItemsBase> items = _projectHolder.Items;

            // preselect item
            foreach (ItemsBase item in items)
            {
                if (item == null)
                    continue;

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

        protected void _projectView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            OpenItem(e);
        }

        private void _editImage_Click(object sender, MouseEventArgs e)
        {
            Point localMousePosition = _editImage.PointToClient(Cursor.Position);
            _imageEditor.ClickImage(localMousePosition, e.Button);
        }

        private void _editImage_MouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            Point localMousePosition = _editImage.PointToClient(Cursor.Position);
            _imageEditor.MoveInImage(localMousePosition, mouseEventArgs);
        }

        private void _pictureColors_Click(object sender, EventArgs e)
        {
            Point localMousePosition = _pictureColors.PointToClient(Cursor.Position);
            _imageEditor.ClickImageColor(localMousePosition);
        }

        private void _pictureColors_MouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            Point localMousePosition = _editImage.PointToClient(Cursor.Position);
            _imageEditor.ClickImageColor(localMousePosition);
        }

        private void _projectView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs mouseEventArgs)
        {
            ItemsBase itemBase = mouseEventArgs.Node.Tag as ItemsBase;
            if (itemBase == null)
                return;

            _clickedOnItem = itemBase;

            if (itemBase.ItemType == ItemTypes.Animation)
            {
                ContextMenu cm = new ContextMenu();
                cm.MenuItems.AddRange(itemBase.CreateContextMenu());
                _projectView.ContextMenu = cm;
                return;
            }
            if (mouseEventArgs.Button == MouseButtons.Right)
            {
                ContextMenu cm = new ContextMenu();
                cm.MenuItems.AddRange(itemBase.CreateContextMenu());
                _projectView.ContextMenu = cm;
                return;
            }
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

        private void EditorMouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int wheelDelta = e.Delta / 120;
            Point localMousePosition = _editImage.PointToClient(Cursor.Position);
            _imageEditor.MoveWheelImage(localMousePosition, wheelDelta);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            _imageEditor.KeyPressed(e);
        }

        private void InitializeServices()
        {
            ServiceLocator.Instance.InjectService<IExportImage>(new ExportImages());
            ServiceLocator.Instance.InjectService<IMainUI>(this);
            ServiceLocator.Instance.InjectService<ProjectHolder>(_projectHolder);
        }

        private void OpenItem(TreeViewEventArgs e)
        {
            ItemsBase itemBase = e.Node.Tag as ItemsBase;
            _selectedItem = itemBase;
            if (itemBase.ItemType == ItemTypes.Animation)
            {
                if (itemBase is IEditable editable)
                {
                    _imageEditor.SetItem(editable);
                    AnimationDetails animationDetails = itemBase as AnimationDetails;
                    _propertyGrid.SelectedObject = animationDetails.AnimationOptions;
                }
            }
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
            try
            {
                string name = _selectedItem.Name + " " + ((IEditable)_selectedItem).CurrentFrame;
                this.Text = name;
            }
            catch { }
        }
    }
}
