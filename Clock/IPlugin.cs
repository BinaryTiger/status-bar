using System.Collections.Generic;

public interface IPlugin
{
    //MENDATORY FIELDS
    //THEY ARE ALREADY SET UP IN THE GENERAL PLUGIN.CS
    //OVERRIDE ONLY IF YOU NEED SPECIFIC COMPUTING ON THEM
    string name { get; set; }
    int priority { get; set; }
    int refreshInterval { get; set; }
    bool isLong { get; set; }
    Dictionary<string, string> customArgs { get; set; }


    //MENDATORY METHODS
    //YOU HAVE TO IMPLEMENT THEM
    void buildCustomArgs(); 
    string showLong();
    string showShort();
}

