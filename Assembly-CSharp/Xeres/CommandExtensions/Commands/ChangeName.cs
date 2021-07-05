using UnityEngine;
using System;
namespace Xeres.CommandExtensions.Commands
{
    public class ChangeName : Command
    {
        private string[] names = { "name","nick" };
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
                return "Changes your current name to whatever you choose";
            }
        }
        public override void executeCommand(string args)
        {
            PhotonNetwork.player.customProperties[PhotonPlayerProperty.name] = args;
            FengGameManagerMKII.instance.name = args;
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
            addLINE("Name changed to: " + RCextensions.returnStringFromObject(PhotonNetwork.player.customProperties[PhotonPlayerProperty.name]).hexColor());

        }
    }
}
