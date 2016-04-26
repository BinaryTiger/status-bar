using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatusBar
{
    class Settings
    {
        public int width { get; set; }
        public int height { get; set; }
        public string color { get; set; }
        public double opacity { get; set; }
        public int padding { get; set; }
        public int screenNumber { get; set; }
        public Plugin[] plugins { get; set; }

        public Screen screen { get; set; }

        public Settings()
        {

        }

        public void updateBar(statusBar bar)
        {
            bar.ClientSize = new System.Drawing.Size(this.width, this.height);
            bar.Height = this.height;
            bar.Opacity = opacity;
            bar.BackColor = System.Drawing.ColorTranslator.FromHtml(this.color);

            if(screenNumber == 1)
            {
                this.screen = Screen.PrimaryScreen;
            }
            else
            {
                Screen[] allScreens = Screen.AllScreens;

                this.screen = allScreens[screenNumber - 1];
            }

            bar.Location = this.screen.WorkingArea.Location;
        }
    }
}
