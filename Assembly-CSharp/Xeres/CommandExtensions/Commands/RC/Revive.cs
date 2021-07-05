using UnityEngine;
using System;
namespace Xeres.CommandExtensions.Commands
{
	public class ReviveAll : Command
	{
		private string[] names = { "revive","reviveall" };
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
				return "[MC] Revives player or revives all players";
			}
		}
		public override void executeCommand(string args)
		{
			if (PhotonNetwork.isMasterClient)
			{
				int victimID;
				if (!Int32.TryParse(args, out victimID))
				{
					object[] parameters3 = new object[2]
					{
									"<color=#a60d1a>All players have been revived.</color>",
									string.Empty
					};
					FengGameManagerMKII.instance.photonView.RPC("Chat", PhotonTargets.All, parameters3);
					PhotonPlayer[] playerList = PhotonNetwork.playerList;
					foreach (PhotonPlayer photonPlayer3 in playerList)
					{
						if (photonPlayer3.customProperties[PhotonPlayerProperty.dead] != null && RCextensions.returnBoolFromObject(photonPlayer3.customProperties[PhotonPlayerProperty.dead]) && RCextensions.returnIntFromObject(photonPlayer3.customProperties[PhotonPlayerProperty.isTitan]) != 2)
						{
							FengGameManagerMKII.instance.photonView.RPC("respawnHeroInNewRound", photonPlayer3);
						}
					}
				}
				else
				{
					PhotonPlayer[] playerList = PhotonNetwork.playerList;
					foreach (PhotonPlayer photonPlayer4 in playerList)
					{
						if (photonPlayer4.ID == victimID)
						{
							addLINE("<color=#a60d1a>Player " + victimID + " has been revived.</color>");
							if (photonPlayer4.customProperties[PhotonPlayerProperty.dead] != null && RCextensions.returnBoolFromObject(photonPlayer4.customProperties[PhotonPlayerProperty.dead]) && RCextensions.returnIntFromObject(photonPlayer4.customProperties[PhotonPlayerProperty.isTitan]) != 2)
							{
								object[] parameters3 = new object[2]
								{
												"<color=#a60d1a>You have been revived by the master client.</color>",
												string.Empty
								};
								FengGameManagerMKII.instance.photonView.RPC("Chat", photonPlayer4, parameters3);
								FengGameManagerMKII.instance.photonView.RPC("respawnHeroInNewRound", photonPlayer4);
							}
						}
					}
				}
			}
			else
			{
				this.addLINE("You are not master client.");
			}
		}
	}
}
