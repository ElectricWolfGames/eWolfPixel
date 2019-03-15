namespace eWolfPixelCoreUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._propertyGrid = new System.Windows.Forms.PropertyGrid();
            this._projectView = new System.Windows.Forms.TreeView();
            this._pictureColors = new System.Windows.Forms.PictureBox();
            this._animImage = new System.Windows.Forms.PictureBox();
            this._previewImage = new System.Windows.Forms.PictureBox();
            this._editImage = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ColorPreviewPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureColors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._animImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._previewImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._editImage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ColorPreviewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._propertyGrid);
            this.splitContainer1.Panel1.Controls.Add(this._projectView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitContainer1.Panel2.Controls.Add(this._ColorPreviewPictureBox);
            this.splitContainer1.Panel2.Controls.Add(this._pictureColors);
            this.splitContainer1.Panel2.Controls.Add(this._animImage);
            this.splitContainer1.Panel2.Controls.Add(this._previewImage);
            this.splitContainer1.Panel2.Controls.Add(this._editImage);
            this.splitContainer1.Panel2.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.EditorMouseWheel);
            this.splitContainer1.Size = new System.Drawing.Size(1070, 669);
            this.splitContainer1.SplitterDistance = 356;
            this.splitContainer1.TabIndex = 0;
            // 
            // _propertyGrid
            // 
            this._propertyGrid.Location = new System.Drawing.Point(8, 410);
            this._propertyGrid.Name = "_propertyGrid";
            this._propertyGrid.Size = new System.Drawing.Size(345, 256);
            this._propertyGrid.TabIndex = 1;
            // 
            // _projectView
            // 
            this._projectView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._projectView.Location = new System.Drawing.Point(8, 8);
            this._projectView.Name = "_projectView";
            this._projectView.Size = new System.Drawing.Size(345, 396);
            this._projectView.TabIndex = 0;
            this._projectView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this._projectView_AfterSelect);
            this._projectView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._projectView_NodeMouseClick);
            // 
            // _pictureColors
            // 
            this._pictureColors.Image = ((System.Drawing.Image)(resources.GetObject("_pictureColors.Image")));
            this._pictureColors.Location = new System.Drawing.Point(419, 54);
            this._pictureColors.Name = "_pictureColors";
            this._pictureColors.Size = new System.Drawing.Size(246, 120);
            this._pictureColors.TabIndex = 3;
            this._pictureColors.TabStop = false;
            this._pictureColors.Click += new System.EventHandler(this._pictureColors_Click);
            this._pictureColors.MouseMove += new System.Windows.Forms.MouseEventHandler(this._pictureColors_MouseMove);
            // 
            // _animImage
            // 
            this._animImage.Location = new System.Drawing.Point(419, 378);
            this._animImage.Name = "_animImage";
            this._animImage.Size = new System.Drawing.Size(167, 176);
            this._animImage.TabIndex = 2;
            this._animImage.TabStop = false;
            // 
            // _previewImage
            // 
            this._previewImage.Location = new System.Drawing.Point(419, 196);
            this._previewImage.Name = "_previewImage";
            this._previewImage.Size = new System.Drawing.Size(167, 176);
            this._previewImage.TabIndex = 1;
            this._previewImage.TabStop = false;
            // 
            // _editImage
            // 
            this._editImage.Location = new System.Drawing.Point(13, 54);
            this._editImage.Name = "_editImage";
            this._editImage.Size = new System.Drawing.Size(400, 500);
            this._editImage.TabIndex = 0;
            this._editImage.TabStop = false;
            this._editImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this._editImage_Click);
            this._editImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this._editImage_MouseMove);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1070, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveProjectToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveProjectToolStripMenuItem
            // 
            this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.saveProjectToolStripMenuItem.Text = "Save Project";
            this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.SaveProjectToolStripMenuItem_Click);
            // 
            // _ColorPreviewPictureBox
            // 
            this._ColorPreviewPictureBox.Location = new System.Drawing.Point(13, 8);
            this._ColorPreviewPictureBox.Name = "_ColorPreviewPictureBox";
            this._ColorPreviewPictureBox.Size = new System.Drawing.Size(432, 41);
            this._ColorPreviewPictureBox.TabIndex = 4;
            this._ColorPreviewPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 693);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pictureColors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._animImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._previewImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._editImage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ColorPreviewPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView _projectView;
        private System.Windows.Forms.PictureBox _previewImage;
        private System.Windows.Forms.PictureBox _editImage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.PictureBox _animImage;
        private System.Windows.Forms.PictureBox _pictureColors;
        private System.Windows.Forms.PropertyGrid _propertyGrid;
        private System.Windows.Forms.PictureBox _ColorPreviewPictureBox;
    }
}

