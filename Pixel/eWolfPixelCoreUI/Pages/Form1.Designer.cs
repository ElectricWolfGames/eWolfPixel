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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._projectView = new System.Windows.Forms.TreeView();
            this._previewImage = new System.Windows.Forms.PictureBox();
            this._editImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._previewImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._editImage)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._projectView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitContainer1.Panel2.Controls.Add(this._previewImage);
            this.splitContainer1.Panel2.Controls.Add(this._editImage);
            this.splitContainer1.Size = new System.Drawing.Size(1070, 693);
            this.splitContainer1.SplitterDistance = 356;
            this.splitContainer1.TabIndex = 0;
            // 
            // _projectView
            // 
            this._projectView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._projectView.Location = new System.Drawing.Point(8, 8);
            this._projectView.Name = "_projectView";
            this._projectView.Size = new System.Drawing.Size(345, 682);
            this._projectView.TabIndex = 0;
            this._projectView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this._projectView_AfterSelect);
            this._projectView.MouseClick += new System.Windows.Forms.MouseEventHandler(this._projectView_MouseClick);
            // 
            // _previewImage
            // 
            this._previewImage.Location = new System.Drawing.Point(451, 341);
            this._previewImage.Name = "_previewImage";
            this._previewImage.Size = new System.Drawing.Size(167, 176);
            this._previewImage.TabIndex = 1;
            this._previewImage.TabStop = false;
            // 
            // _editImage
            // 
            this._editImage.Location = new System.Drawing.Point(46, 50);
            this._editImage.Name = "_editImage";
            this._editImage.Size = new System.Drawing.Size(399, 467);
            this._editImage.TabIndex = 0;
            this._editImage.TabStop = false;
            this._editImage.Click += new System.EventHandler(this._editImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 693);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyPreview = true;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._previewImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._editImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView _projectView;
        private System.Windows.Forms.PictureBox _previewImage;
        private System.Windows.Forms.PictureBox _editImage;
    }
}

