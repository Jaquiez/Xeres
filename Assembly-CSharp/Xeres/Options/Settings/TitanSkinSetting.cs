using System;
using SimpleJSON;
using System.IO;
using UnityEngine;
using ExitGames.Client.Photon;
using System.Collections.Generic;
namespace Xeres.Options.Settings
{
    public class TitanSkinSetting : Setting
    {
        private static Hashtable rawSetting;

        public override Hashtable userData
        {
            get => rawSetting;
            set => rawSetting = value;
        }

        public override string configDirectory => Application.dataPath + @"/Config/SkinSets/TitanSkinSets/";
        public override string name => "TitanSet";

        public string currentSet;

        public override void setUserData(string fileName)
        {
            userData = formatText(fileName + ".txt");
            currentSet = fileName;
        }
        public Hashtable formatText(string fileName)
        {
            Hashtable preset = new Hashtable();
            string[] text = File.ReadAllLines(configDirectory + fileName);
            foreach (string line in text)
            {

                int index = line.IndexOf(":");
                if (index <= 0)
                    continue;
                preset.Add(line.Substring(0, index), line.Substring(index + 1));
            }
            return preset;
        }
        public override Hashtable getTempUserData(string fileName)
        {
            if (File.Exists(Application.dataPath + @"/Config/SkinSets/TitanSkinSets/" + fileName + ".txt"))
            {
                return formatText(fileName + ".txt");
            }
            else
                return null;
        }
        public override void createEmptyFile(string fileName)
        {
            string[] keys = {"Hair:,,,,,", "HairModel:,,,,,", "Eye:,,,,,", "Body:,,,,,", "Eren:", "Annie:", "Colossal:" };
            File.WriteAllLines(configDirectory + fileName + ".txt", keys);
        }

    }
}
