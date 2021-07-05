using UnityEngine;
using ExitGames.Client.Photon;
using System;
namespace Xeres.CommandExtensions.Commands
{
    public class ResetKDAll : Command
    {
        private string[] names = { "resetkdall" };
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
                return "[MC] Resets K/D for the whole server";
            }
        }
        public override void executeCommand(string args)
        {
            Hashtable hashtable;
            if (PhotonNetwork.isMasterClient)
            {
                foreach (PhotonPlayer player in PhotonNetwork.playerList)
                {
                    hashtable = new Hashtable();
                    hashtable.Add(PhotonPlayerProperty.kills, 0);
                    hashtable.Add(PhotonPlayerProperty.deaths, 0);
                    hashtable.Add(PhotonPlayerProperty.max_dmg, 0);
                    hashtable.Add(PhotonPlayerProperty.total_dmg, 0);
                    player.SetCustomProperties(hashtable);
                }
                FengGameManagerMKII.instance.photonView.RPC("Chat", PhotonTargets.All, new object[] { "<color=#a60d1a><b> All stats have been reset. </b></color>", "" });
            }
            else
            {
                this.addLINE("You are not master client.");
            }
        }
    }
}
