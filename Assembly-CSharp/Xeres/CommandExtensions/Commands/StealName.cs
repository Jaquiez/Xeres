using UnityEngine;
using System;
namespace Xeres.CommandExtensions.Commands
{
    public class StealName : Command
    {
        private string[] names = { "steal" };
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
                return "Steals the name of another player based on ID";
            }
        }
        public override void executeCommand(string args)
        {
            int victimID = Int32.Parse(args);
            GameObject myNetWorkName = GameObject.Find("LabelNameOverHead");
            Console.WriteLine("BEFORE \n" + myNetWorkName.GetComponent<UILabel>().text);
            PhotonPlayer victim = PhotonPlayer.Find(victimID);
            PhotonNetwork.player.customProperties["name"] = RCextensions.returnStringFromObject(victim.customProperties[PhotonPlayerProperty.name]);
            FengGameManagerMKII.instance.name = RCextensions.returnStringFromObject(victim.customProperties[PhotonPlayerProperty.name]);
            PhotonNetwork.player.SetCustomProperties(new ExitGames.Client.Photon.Hashtable { { PhotonPlayerProperty.name, FengGameManagerMKII.instance.name } });
            //Gets our photon view and sends it as a setting
            GameObject[] array2 = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject go in array2)
            {
                if (go.GetPhotonView().isMine)
                {
                    FengGameManagerMKII.instance.photonView.RPC("labelRPC", PhotonTargets.All, go.GetPhotonView().viewID);
                }
            }
            this.addLINE("Name changed to: " + RCextensions.returnStringFromObject(PhotonNetwork.player.customProperties["name"]).hexColor());
            
        }
    }
}
