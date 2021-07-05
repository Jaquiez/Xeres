using UnityEngine;
using System;
namespace Xeres.CommandExtensions.Commands
{
	public class UnBan : Command
	{
		private string[] names = { "unban" };
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
				return "Unbans someone";
			}
		}
		public override void executeCommand(string args)
		{
			/*
			if (!MasterServerAddress.StartsWith("app-"))
			{
				FengGameManagerMKII.ServerRequestUnban(args);
			}*/
			if (PhotonNetwork.isMasterClient)
			{
				int num3 = Convert.ToInt32(args);
				if (FengGameManagerMKII.banHash.ContainsKey(num3))
				{
					object[] parameters3 = new object[2]
					{
									"<color=#a60d1a>" + (string)FengGameManagerMKII.banHash[num3] + " has been unbanned from the server. </color>",
									string.Empty
					};
					FengGameManagerMKII.instance.photonView.RPC("Chat", PhotonTargets.All, parameters3);
					FengGameManagerMKII.banHash.Remove(num3);
				}
				else
				{
					addLINE("No such player");
				}
			}
			else
			{
				addLINE("Not master client");
			}
		}
	}
}
