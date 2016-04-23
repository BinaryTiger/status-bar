using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace StatusBar
{
    public partial class statusBar : Form
    {
        public PluginManager manager { get; set; }
        Dictionary<string, string> updates;


        public statusBar(PluginManager manager)
        {
            InitializeComponent();
            this.manager = manager;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
        }

        private void statusBar_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {           
            this.updates = this.manager.getUpdates();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (KeyValuePair<string, string> update in this.updates)
            {
                this.updateText(update.Key, update.Value);
                this.updateLeft(update.Key);
            }
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
