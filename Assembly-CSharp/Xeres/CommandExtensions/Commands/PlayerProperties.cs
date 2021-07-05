using UnityEngine;
using System;
namespace Xeres.CommandExtensions.Commands
{
    public class PlayerProperties : Command
    {
        private string[] names = { "getprops" };
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
                return "[DEBUG] Shows the custom properties of another user";
            }
        }
        public override void executeCommand(string args)
        {
            int victimID = Int32.Parse(args);
            foreach (PhotonPlayer player in PhotonNetwork.playerList)
            {
                if (victimID == player.ID)
                {                 
                    this.addLINE(player.customProperties.ToStringFull());
                }
            }
        }
    }
}
