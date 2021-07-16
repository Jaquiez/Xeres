using UnityEngine;
using System;
using Xeres.Options;
using System.Collections;

namespace Xeres.CommandExtensions.Commands
{
    public class LoadSkin : Command
    {
        private string[] names = { "loadskin" };
        public override string[] commandNames
        {
            get
            {
                return names;
            }
        }
        public override string description
        {
            get
            {
                return "Loads a skin from config";
            }
        }
        public override void executeCommand(string args)
        {
            foreach(Setting setting in GameObject.Find("XeresManager").GetComponent<SettingHandler>().settings)
            {
                if(setting.name.Equals("HumanSet"))
                {
                    string url = "";
                    foreach(DictionaryEntry entry in setting.userData)
                    {
                        url += entry.Value + ",";
                    }
                    url.Substring(0, url.LastIndexOf(',')-1);
                    addLINE("Adding " + url);
                    
                    GameObject.FindGameObjectWithTag("Player").GetComponent<HERO>().photonView.RPC("loadskinRPC", PhotonTargets.AllBuffered, new object[] { -1, url });
                }
            }
        }
    }
}
