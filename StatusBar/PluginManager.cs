using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusBar
{
    class PluginManager
    {
        List<Object> plugins { get; set; }

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
    }
}
