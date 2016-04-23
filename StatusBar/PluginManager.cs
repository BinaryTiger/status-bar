using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace StatusBar
{
    public class PluginManager
    {
        List<Object> plugins { get; set; }
        int cycles = 0;
        int resetCyclesCounter = int.MaxValue - 10000;

        public PluginManager()
        {
            this.plugins = new List<object>();
        }

        public void addPlugin(Object plugin)
        {
            this.plugins.Add(plugin);
        }

        //Debuggin purposes
        public void showPluginNameList()
        {
            foreach(Object plugin in plugins)
            {
                System.Diagnostics.Debug.WriteLine("Plugin name: " + plugin.GetType().GetProperty("name").GetValue(plugin));
            }

        }

        public Dictionary<string,string> getUpdates()
        {
            Dictionary<string, string> updates = new Dictionary<string, string>();

            foreach(Object plugin in plugins)
            {
                //DO PROCESSING ON PLUGINS
                if(cycles % (int)plugin.GetType().GetProperty("refreshInterval").GetValue(plugin) == 0)
                {
                    //DO THINGS CAUSE ITS TIME TO SHINE BABY
                    MethodInfo methodShowLong = plugin.GetType().GetMethod("showLong");
                    string textToDisplay = (string)methodShowLong.Invoke(plugin, null);
                    updates.Add((string)plugin.GetType().GetProperty("name").GetValue(plugin), textToDisplay);
                }

            }

            cycles++;

            if (cycles >= resetCyclesCounter)
            {
                cycles = 0;
            }

            return updates;
        }
    }
}
