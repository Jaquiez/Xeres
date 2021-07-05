using UnityEngine;
using System;
namespace Xeres.CommandExtensions.Commands
{
    public class PrivateMessage : Command
    {
        private string[] names = { "pm","msg" };
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
				return "Private message the id you choose with the current message";
			}
		}
		public override void executeCommand(string args)
        {
			string[] array = args.Split(' ');
			PhotonPlayer photonPlayer2 = PhotonPlayer.Find(Convert.ToInt32(array[0]));
			string text = RCextensions.returnStringFromObject(PhotonNetwork.player.customProperties[PhotonPlayerProperty.name]).hexColor();
			if (text == string.Empty)
			{
				text = RCextensions.returnStringFromObject(PhotonNetwork.player.customProperties[PhotonPlayerProperty.name]);
				if (PhotonNetwork.player.customProperties[PhotonPlayerProperty.RCteam] != null)
				{
					if (RCextensions.returnIntFromObject(PhotonNetwork.player.customProperties[PhotonPlayerProperty.RCteam]) == 1)
					{
						text = "<color=#00FFFF>" + text + "</color>";
					}
					else if (RCextensions.returnIntFromObject(PhotonNetwork.player.customProperties[PhotonPlayerProperty.RCteam]) == 2)
					{
						text = "<color=#FF00FF>" + text + "</color>";
					}
				}
			}
			string text2 = RCextensions.returnStringFromObject(photonPlayer2.customProperties[PhotonPlayerProperty.name]).hexColor();
			if (text2 == string.Empty)
			{
				text2 = RCextensions.returnStringFromObject(photonPlayer2.customProperties[PhotonPlayerProperty.name]);
				if (photonPlayer2.customProperties[PhotonPlayerProperty.RCteam] != null)
				{
					if (RCextensions.returnIntFromObject(photonPlayer2.customProperties[PhotonPlayerProperty.RCteam]) == 1)
					{
						text2 = "<color=#00FFFF>" + text2 + "</color>";
					}
					else if (RCextensions.returnIntFromObject(photonPlayer2.customProperties[PhotonPlayerProperty.RCteam]) == 2)
					{
						text2 = "<color=#FF00FF>" + text2 + "</color>";
					}
				}
			}
			string text3 = string.Empty;
			for (int j = 1; j < array.Length; j++)
			{
				text3 = text3 + array[j] + " ";
			}
			FengGameManagerMKII.instance.photonView.RPC("ChatPM", photonPlayer2, text, text3);
			addLINE("<color=#FFC000>TO [" + photonPlayer2.ID + "]</color> " + text2 + "<color=#FFFFFF> :" + text3 + "</color>");
		}
    }
}
