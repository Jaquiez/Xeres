using UnityEngine;
using System;
namespace Xeres.CommandExtensions.Commands
{
	public class Restart : Command
	{
		private string[] names = { "restart" };
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
				return "[MC] Restarts the game";
			}
		}
		public override void executeCommand(string args)
		{
			if (PhotonNetwork.isMasterClient)
			{
				object[] parameters2 = new object[2] { "<color=#a60d1a><b> MasterClient has restarted the game! </b></color>", "" };
				FengGameManagerMKII.instance.photonView.RPC("Chat", PhotonTargets.All, parameters2);
				FengGameManagerMKII.instance.restartRC();
			}
			else
			{
				this.addLINE("You are not master client.");
			}
		}
	}
}
