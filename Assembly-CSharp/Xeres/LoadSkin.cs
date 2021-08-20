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
                    ExitGames.Client.Photon.Hashtable entries = setting.getTempUserData("Skinset" + args);
                    foreach(DictionaryEntry entry in entries)
                    {
                        url += entry.Value + ",";
                    }
                    url.Substring(0, url.LastIndexOf(','));
                    addLINE("Adding " + url);

                    GameObject[] array2 = GameObject.FindGameObjectsWithTag("Player");
                    foreach (GameObject go in array2)
                    {                      
                        if (go.GetPhotonView().isMine)
                        {
                            foreach (Renderer renderer in go.GetComponentsInChildren<Renderer>())
                            {
                                renderer.enabled = true;
                            }
                            foreach(var thing in FengGameManagerMKII.linkHash)
                            {
                                thing.Clear();
                            }
                            go.GetComponent<HERO>().photonView.RPC("loadskinRPC", PhotonTargets.AllBuffered, new object[] { -1, url });
                        }
                    }


                }
            }
        }

    }
}
