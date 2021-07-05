using UnityEngine;
namespace Xeres.CommandExtensions.Commands
{
    public class InfiniteAHSS : Command
    {
        private string[] names = { "infAHSS" };
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
                return "Toggles infinite AHSS";
            }
        }
        public override void executeCommand(string args)
        {
            if (RCextensions.returnBoolFromObject(PhotonNetwork.player.customProperties[XeresProperty.infiniteAHSS]))
            {
                ExitGames.Client.Photon.Hashtable hashtable3 = new ExitGames.Client.Photon.Hashtable();
                hashtable3.Add(XeresProperty.infiniteAHSS, false);
                PhotonNetwork.player.SetCustomProperties(hashtable3);
                this.addLINE("<color=#b31225> Infinite AHSS Disabled! </color> ");
            }
            else
            {
                ExitGames.Client.Photon.Hashtable hashtable3 = new ExitGames.Client.Photon.Hashtable();
                hashtable3.Add(XeresProperty.infiniteAHSS, true);
                PhotonNetwork.player.SetCustomProperties(hashtable3);
                this.addLINE("<color=#07522c> Infinite AHSS Enabled! </color> ");
            }
        }
    }
}
