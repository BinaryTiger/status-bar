using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusBar
{
    public class Plugin : IPlugin
    {
        public Dictionary<string, string> customArgs { get; set; }

        public string name { get; set; }

        public int priority { get; set; }

        public int refreshInterval { get; set; }

        public bool isLong { get; set; }

        public string showLong()
        {
            return "You should implement this in your plugin (long show)";
        }

        public string showShort()
        {
            return "You should implement this in your plugin (short show)";
        }
    }
}
