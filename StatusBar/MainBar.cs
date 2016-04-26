using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Timers;
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

        public void updateLeft2()
        {
            int previousLabelPosition = this.Width;

            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(Label))
                {
                    Label l = (Label)c;
                    int left = previousLabelPosition - l.Width - 10;
                    l.Left = left;
                    previousLabelPosition = left;
                }                   
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            this.updates = this.manager.getUpdates();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (KeyValuePair<string, string> update in this.updates)
            {
                System.Diagnostics.Debug.WriteLine("Key: " + update.Key);
                System.Diagnostics.Debug.WriteLine("Value: " + update.Value);
                this.updateText(update.Key, update.Value);
                this.updateLeft2();
            }

            backgroundWorker1.RunWorkerAsync();
        }
    }
}
