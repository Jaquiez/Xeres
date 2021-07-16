using SimpleJSON;
using System;
using UnityEngine;
using System.IO;
using ExitGames.Client.Photon;

namespace Xeres.Options.Settings
{
    public class MainSettings : Setting
    {
        Hashtable rawSetting;
        public override Hashtable userData 
        {
            get => rawSetting;
            set => rawSetting = value;
        }

        public override string configDirectory => Application.dataPath + @"/Config/";
        public override string name => "ValuesToUse";

        public override void setUserData(string fileName)
        {
            rawSetting = formatText(fileName);
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
