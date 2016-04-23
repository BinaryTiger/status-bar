using System;
using System.Collections.Generic;


public class Clock : Plugin
{
    public Clock(string name, int priority, int refreshInterval, bool isLong, Dictionary<string, string> customArgs) : base(name, priority, refreshInterval, isLong, customArgs)
    {
    }

    public Clock() { }

    string dateFormatShort { get; set; }
    string dateFormatLong { get; set; }

    public new void buildCustomArgs()
    {
        if (this.customArgs.ContainsKey("dateFormatshort"))
        {
            this.dateFormatShort = this.customArgs["dateFormatshort"];
        }
        else
        {
            this.dateFormatShort = "hh:mm:ss";
        }

        if (this.customArgs.ContainsKey("dateFormatLong"))
        {
            this.dateFormatLong = this.customArgs["dateFormatLong"];
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
