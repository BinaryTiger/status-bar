using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StatusBar
{
    class SettingReader
    {
        private string path { get; set; }
        private string rawSettings { get; set; }
        private Settings settings { get; set; }

        public SettingReader()
        {
            this.path = "settings.json";
            this.settings = null;
        }

        public SettingReader(string path)
        {
            this.path = path;
            this.settings = null;
        }

        private void readSettingFile()
        {
            this.rawSettings = System.IO.File.ReadAllText(this.path);            
        }

        public Settings getSettings()
        {
            if (this.settings == null)
            {
                this.readSettingFile();
                this.settings = JsonConvert.DeserializeObject<Settings>(this.rawSettings);
            }

            return this.settings;
        }


    }
}
