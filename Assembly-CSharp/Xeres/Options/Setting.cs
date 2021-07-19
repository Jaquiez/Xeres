using System.IO;
using ExitGames.Client.Photon;
using System;
using UnityEngine;
using System.Collections.Generic;
public abstract class Setting
{

    public abstract Hashtable userData
    {
        get;
        set;
    }

    public abstract string configDirectory
    {
        get;
    }
    public abstract string name
    {
        get;
    }
    public abstract void setUserData(string fileName);

    public abstract Hashtable getTempUserData(string filename);

    public void saveHashtableToFile(Hashtable hashtable, string file)
    {
        List<string> lines = new List<string>();
        foreach (var entry in hashtable)
        {
            lines.Add(entry.Key + ":" + entry.Value);
        }
        File.WriteAllLines(configDirectory + file + ".txt", lines.ToArray());
    }

    public abstract void createEmptyFile(string name);

    public Hashtable formatText(string fileName)
    {
        Hashtable preset = new Hashtable();
        string[] text = File.ReadAllLines(configDirectory + fileName);
        foreach(string line in text)
        {

            int index = line.IndexOf(":");
            if (index <= 0)
                continue;
            preset.Add(line.Substring(0, index), line.Substring(index + 1));
        }
        return preset;
    }

}
