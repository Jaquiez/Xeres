using UnityEngine;
using System;
namespace Xeres.CommandExtensions.Commands
{
	public class Kick : Command
	{
		private string[] names = { "kick" };
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
                return "[MC] Kicks the ID you choose";
            }
        }
        public override void executeCommand(string args)
		{
			int num8 = Convert.ToInt32(args);
            bool flag2;
            if (num8 == PhotonNetwork.player.ID)
            {
                this.addLINE("Can't kick yourself.");
                return;
            }
            else if (!(FengGameManagerMKII.OnPrivateServer || PhotonNetwork.isMasterClient))
            {
                FengGameManagerMKII.instance.photonView.RPC("Chat", PhotonTargets.All, new object[] { "/kick #" + Convert.ToString(num8), LoginFengKAI.player.name });
            }
            else
            {
                flag2 = false;
                foreach (PhotonPlayer player3 in PhotonNetwork.playerList)
                {
                    if (num8 == player3.ID)
                    {
                        flag2 = true;
                        if (FengGameManagerMKII.OnPrivateServer)
                        {
                            FengGameManagerMKII.instance.kickPlayerRC(player3, false, "");
                        }
                        else if (PhotonNetwork.isMasterClient)
                        {
                            FengGameManagerMKII.instance.kickPlayerRC(player3, false, "");
                            FengGameManagerMKII.instance.photonView.RPC("Chat", PhotonTargets.All, new object[] { "<color=#a60d1a>" + RCextensions.returnStringFromObject(player3.customProperties[PhotonPlayerProperty.name]) + " has been kicked from the server!</color>", string.Empty });
                        }
                    }
                }
                if (!flag2)
                {
                    this.addLINE("error:no such player.");
                }
            }
        }
	}
}
