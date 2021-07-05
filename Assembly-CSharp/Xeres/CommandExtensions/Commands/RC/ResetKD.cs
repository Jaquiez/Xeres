using UnityEngine;
using ExitGames.Client.Photon;
using System;
namespace Xeres.CommandExtensions.Commands
{
    public class ResetKD : Command
    {
        private string[] names = { "resetkd" };
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
                return "Resets your K/D";
            }
        }
        public override void executeCommand(string args)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add(PhotonPlayerProperty.kills, 0);
            hashtable.Add(PhotonPlayerProperty.deaths, 0);
            hashtable.Add(PhotonPlayerProperty.max_dmg, 0);
            hashtable.Add(PhotonPlayerProperty.total_dmg, 0);
            PhotonNetwork.player.SetCustomProperties(hashtable);
            this.addLINE("Your stats have been reset.");
        }
    }
}
