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
            PluginManager manager = new PluginManager();
            statusBar mainStatusBar;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainStatusBar = new statusBar();

            // Applying the custom bar parameters
            SettingReader sr = new SettingReader();
            Settings settings = sr.getSettings();

            settings.updateBar(mainStatusBar);

            foreach (Plugin p in settings.plugins)
            {
                try
                {
                    ObjectHandle handle = Activator.CreateInstance(p.name, p.name);
                    Object plugin = handle.Unwrap();
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

                    manager.addPlugin(plugin);

                    //MethodInfo methodShowLong = t.GetMethod("showLong");
                    //string textToDisplay = (string)methodShowLong.Invoke(plugin, null);

                    Label labelToAdd = new Label();
                    labelToAdd.Name = p.name;
                    labelToAdd.MinimumSize = new Size(settings.height, 10);
                    labelToAdd.AutoSize = true;
                    labelToAdd.Text = "test";                                     
                    labelToAdd.Top = 5;             

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

            mainStatusBar.updateLeft("Clock");
            manager.showPluginNameList();



            //System.Diagnostics.Debug.WriteLine("Plugins: " + settings.plugins[0].name);
            //System.Diagnostics.Debug.WriteLine("Plugins: " + settings.plugins[0].customArgs["dateFormatShort"]);

            //System.Diagnostics.Debug.WriteLine("we get there");
            Application.Run(mainStatusBar);

        }
    }
}
