namespace eWolfPixelUI.Pages
{
    partial class NameItem
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
            this._cancelButton = new System.Windows.Forms.Button();
            this._OkButton = new System.Windows.Forms.Button();
            this._textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(12, 96);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 0;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _OkButton
            // 
            this._OkButton.Location = new System.Drawing.Point(480, 96);
            this._OkButton.Name = "_OkButton";
            this._OkButton.Size = new System.Drawing.Size(75, 23);
            this._OkButton.TabIndex = 1;
            this._OkButton.Text = "Ok";
            this._OkButton.UseVisualStyleBackColor = true;
            this._OkButton.Click += new System.EventHandler(this._OkButton_Click);
            // 
            // _textBox
            // 
            this._textBox.Location = new System.Drawing.Point(12, 32);
            this._textBox.Name = "_textBox";
            this._textBox.Size = new System.Drawing.Size(543, 20);
            this._textBox.TabIndex = 2;
            // 
            // NameItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 131);
            this.Controls.Add(this._textBox);
            this.Controls.Add(this._OkButton);
            this.Controls.Add(this._cancelButton);
            this.Name = "NameItem";
            this.Text = "NameItem";
            this.Load += new System.EventHandler(this.NameItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _OkButton;
        private System.Windows.Forms.TextBox _textBox;
    }
}