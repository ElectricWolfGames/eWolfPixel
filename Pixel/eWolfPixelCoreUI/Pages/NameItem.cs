using System;
using System.Windows.Forms;

namespace eWolfPixelUI.Pages
{
    public partial class NameItem : Form
    {
        public NameItem()
        {
            InitializeComponent();
        }

        public bool Apply { get; set; }

        public string NewName { get; set; }

        public string TitleText { get; set; }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            Apply = false;
            Close();
        }

        private void _OkButton_Click(object sender, EventArgs e)
        {
            NewName = _textBox.Text;
            Apply = true;
            Close();
        }

        private void NameItem_Load(object sender, EventArgs e)
        {
            Text = TitleText;
            _textBox.Text = NewName;
        }
    }
}
