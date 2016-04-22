using System;
using System.Collections.Generic;

namespace StatusBar.plugins
{
    public class Clock : Plugin
    {

        string dateFormatShort { get; set; }
        string dateFormatLong { get; set; }

        public void buildcustomArgs()
        {
            if (this.customArgs.ContainsKey("dateformatshort"))
            {
                this.dateFormatShort = this.customArgs["dateformatshort"];
            }
            else
            {
                this.dateFormatShort = "hh:mm:ss";
            }

            if (this.customArgs.ContainsKey("dateformatlong"))
            {
                this.dateFormatLong = this.customArgs["dateformatlong"];
            }
            else
            {
                this.dateFormatLong = "dd/mm/yyyy hh:mm:ss";
            }
        }

        public new string showLong()
        {
            return DateTime.Now.ToString(this.dateFormatLong);
        }

        public new string showShort()
        {
            return DateTime.Now.ToString(this.dateFormatShort);
        }
    }
}
