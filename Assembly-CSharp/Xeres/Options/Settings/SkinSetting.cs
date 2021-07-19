using System;
using SimpleJSON;
using System.IO;
using UnityEngine;
using ExitGames.Client.Photon;
using System.Collections.Generic;
namespace Xeres.Options.Settings
{
    public class SkinSetting : Setting
    {
        private static Hashtable rawSetting;

        public override Hashtable userData
        {
            get => rawSetting;
            set => rawSetting = value;
        }

        public override string configDirectory => Application.dataPath + @"/Config/HumanSkinSets/";
        public override string name => "HumanSet";

        public string currentSet;

        public override void setUserData(string fileName)
        {
            userData = formatText(fileName + ".txt");
            currentSet = fileName;
        }
        public override Hashtable getTempUserData(string fileName)
        {
            if (File.Exists(Application.dataPath + @"/Config/HumanSkinSets/" + fileName + ".txt"))
            {
                return formatText(fileName + ".txt");
            }
            else
                return null;
        }
        public override void createEmptyFile(string fileName)
        {
            string[] keys = { "horse:", "hair:", "eyes:", "glass:", "face:", "skin:", "costume:", "cape:", "leftGear:", "rightGear:", "gas:", "hoodie:", "weaponTrail:" };
            File.WriteAllLines(configDirectory + fileName + ".txt", keys);
        }

    }
}
