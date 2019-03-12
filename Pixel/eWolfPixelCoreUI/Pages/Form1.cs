using eWolfPixelStandard.Interfaces;
using eWolfPixelStandard.Items;
using eWolfPixelStandard.Project;
using eWolfPixelUI.ImageEditor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace eWolfPixelCoreUI
{
    public partial class Form1 : Form
    {
        private ImageEditor _imageEditor = new ImageEditor();
        private ProjectHolder _projectHolder = new ProjectHolder();

        public Form1()
        {
            InitializeComponent();
            _projectHolder.LoadProject(@"C:\GitHub\eWolfPixel\Pixel\DummyTestProject\");

            PopulateTree();

            _imageEditor.EditImage = _editImage;
            _imageEditor.PreviewImage = _previewImage;
        }

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

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            _imageEditor.KeyPressed(e);
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

        private void SetEditItem(IEditable item)
        {
            _imageEditor.SetItem(item);
        }
    }
}
