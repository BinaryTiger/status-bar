using System;
using System.Drawing;
using System.Windows.Forms;

namespace StatusBar
{
    public partial class statusBar : Form
    {
        public statusBar()
        {
            InitializeComponent();
        }

        private void statusBar_Load(object sender, EventArgs e)
        {
        }

        public void addLabel(Label l)
        {            
            this.Controls.Add(l);
        }

        public void updateText(string labelName, string newText)
        {
            Control[] labelToUpdate = this.Controls.Find(labelName, true);

            foreach(Control c in labelToUpdate)
            {
                Label l = (Label)c;
                l.Text = newText;
            }

        }

        public void updateLeft(string labelName)
        {
            Control[] labelToUpdate = this.Controls.Find(labelName, true);

            foreach (Control c in labelToUpdate)
            {
                Label l = (Label)c;
                l.Left = this.Width - l.Width - 10;
            }

        }
    }
}
