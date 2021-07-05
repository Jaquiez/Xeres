using UnityEngine;
using System;
namespace Xeres.CommandExtensions.Commands
{
    public class Ignore : Command
    {
        private string[] names = { "ignore" };
        public override string [] commandNames
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
                return "Ignores player by not recieving any more data from them";
            }
        }
        public override void executeCommand(string args)
        {
            int victimID = Int32.Parse(args);
            if (victimID == PhotonNetwork.player.ID)
            {
                this.addLINE("Can't ignore yourself!");
                return;
            }
            foreach (PhotonPlayer player in PhotonNetwork.playerList)
            {
                if (victimID == player.ID)
                {
                    if(FengGameManagerMKII.ignoreList.Contains(victimID))
                    {
                        this.addLINE("Unignored " + RCextensions.returnStringFromObject(player.customProperties[PhotonPlayerProperty.name]).hexColor());
                        FengGameManagerMKII.ignoreList.Remove(victimID);
                    }
                    else
                    {
                        this.addLINE("Ignored " + RCextensions.returnStringFromObject(player.customProperties[PhotonPlayerProperty.name]).hexColor());
                        FengGameManagerMKII.ignoreList.Add(player.ID);
                    }
                }
            }
            FengGameManagerMKII.instance.justRecompileThePlayerList();
        }
    }
}
