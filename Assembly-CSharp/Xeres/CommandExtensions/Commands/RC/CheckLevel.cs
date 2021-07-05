using UnityEngine;
using System;
namespace Xeres.CommandExtensions.Commands
{
    public class CheckLevel : Command
    {
        private string[] names = { "checklevel" };
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
                return "Gives you the current level you're in";
            }
        }
        public override void executeCommand(string args)
        {
            foreach (PhotonPlayer player in PhotonNetwork.playerList)
            {
                this.addLINE(RCextensions.returnStringFromObject(player.customProperties[PhotonPlayerProperty.currentLevel]));
            }
        }
    }
}
