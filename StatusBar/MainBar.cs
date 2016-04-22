using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StatusBar.plugins;

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
            Label clockLabel = new Label();
            clockLabel.Top = 5;
            clockLabel.Left = this.Width - clockLabel.Width - 10;
            clockLabel.AutoSize = true;
            clockLabel.Text = DateTime.Now.ToString("HH:mm:ss");
            clockLabel.ForeColor = Color.White;
            System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss"));


            this.Controls.Add(clockLabel);
            //END WILL REFACTOR
        }

        public void addLabel(Label l)
        {
            
            this.Controls.Add(l);
        }
    }
}
