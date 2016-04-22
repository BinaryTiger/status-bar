using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using StatusBar.plugins;

namespace StatusBar
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            statusBar mainStatusBar;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainStatusBar = new statusBar();

            // Applying the custom bar parameters
            SettingReader sr = new SettingReader();
            Settings settings = sr.getSettings();

            settings.updateBar(mainStatusBar);

            System.Diagnostics.Debug.WriteLine("Plugins: " + settings.plugins[0].name);
            System.Diagnostics.Debug.WriteLine("Plugins: " + settings.plugins[0].customArgs["dateFormatShort"]);

            //System.Diagnostics.Debug.WriteLine("we get there");
            Application.Run(mainStatusBar);

        }
    }
}
