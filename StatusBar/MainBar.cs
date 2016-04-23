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
    }
}
