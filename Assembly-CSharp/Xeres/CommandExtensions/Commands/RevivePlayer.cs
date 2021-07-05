using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xeres.CommandExtensions.Commands
{
    public class RevivePlayer : Command
    {
        private string[] names = { "selfrevive","sr" };
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
                return "Revives yourself";
            }
        }
        public override void executeCommand(string args)
        {
            FengGameManagerMKII.instance.photonView.RPC("respawnHeroInNewRound", PhotonNetwork.player, new object[0]);
            this.addLINE("You have been revived!");
        }
    }
}
