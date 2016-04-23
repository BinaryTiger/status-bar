using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Remoting;
using System.Reflection;

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

            foreach(Plugin p in settings.plugins)
            {
                try
                {
                    ObjectHandle handle = Activator.CreateInstance(p.name, p.name);
                    Object plugin = (Object)handle.Unwrap();
                    Type t = plugin.GetType();

                    PropertyInfo propName = t.GetProperty("name");
                    propName.SetValue(plugin, p.name);

                    PropertyInfo propIsLong = t.GetProperty("isLong");
                    propIsLong.SetValue(plugin, p.isLong);

                    PropertyInfo propRefreshInterval = t.GetProperty("refreshInterval");
                    propRefreshInterval.SetValue(plugin, p.refreshInterval);

                    PropertyInfo propCustomArgs = t.GetProperty("customArgs");
                    propCustomArgs.SetValue(plugin, p.customArgs);

                    PropertyInfo propPriority = t.GetProperty("priority");
                    propPriority.SetValue(plugin, p.priority);

                    MethodInfo methodBuildArgs = t.GetMethod("buildCustomArgs");
                    methodBuildArgs.Invoke(plugin, null);

                    MethodInfo methodShowLong = t.GetMethod("showLong");
                    string textToDisplay = (string)methodShowLong.Invoke(plugin, null);

                    Label labelToAdd = new Label();
                    labelToAdd.Text = textToDisplay;
                    labelToAdd.AutoSize = true;
                    labelToAdd.Top = 5;
                    labelToAdd.Left = mainStatusBar.Width - labelToAdd.Width - 10;


                    labelToAdd.ForeColor = Color.White;

                    mainStatusBar.addLabel(labelToAdd);
                }
                catch(TypeLoadException e)
                {
                    System.Diagnostics.Debug.WriteLine("Name: " + p.name);
                    System.Diagnostics.Debug.WriteLine(e.Message);

                    Assembly Clock = Assembly.ReflectionOnlyLoadFrom("Clock.dll");
                    foreach (Type type in Clock.GetTypes())
                    {
                        Console.WriteLine(type.FullName);
                    }
                }
            }

            //System.Diagnostics.Debug.WriteLine("Plugins: " + settings.plugins[0].name);
            //System.Diagnostics.Debug.WriteLine("Plugins: " + settings.plugins[0].customArgs["dateFormatShort"]);

            //System.Diagnostics.Debug.WriteLine("we get there");
            Application.Run(mainStatusBar);

        }
    }
}
