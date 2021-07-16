using System;
using SimpleJSON;
using System.IO;
using UnityEngine;
using ExitGames.Client.Photon;

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

        public override void setUserData(string fileName)
        {
            userData = formatText(fileName + ".txt");
        }
        public override Hashtable getTempUserData(string filename)
        {
            throw new NotImplementedException();
        }

        public override void createEmptyJSON()
        {
            throw new NotImplementedException();
        }

    }
}
