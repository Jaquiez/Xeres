using UnityEngine;
namespace Xeres.CommandExtensions.Commands
{
    public class InfiniteBlades : Command
    {
        private string[] names = { "infBlades"};
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
                return "Toggles infinite blades";
            }
        }
        public override void executeCommand(string args)
        {
            if (RCextensions.returnBoolFromObject(PhotonNetwork.player.customProperties[XeresProperty.infiniteBlades]))
            {
                ExitGames.Client.Photon.Hashtable hashtable3 = new ExitGames.Client.Photon.Hashtable();
                hashtable3.Add(XeresProperty.infiniteBlades, false);
                PhotonNetwork.player.SetCustomProperties(hashtable3);
                this.addLINE("<color=#b31225> Infinite Blades Disabled! </color> ");
            }
            else
            {
                ExitGames.Client.Photon.Hashtable hashtable3 = new ExitGames.Client.Photon.Hashtable();
                hashtable3.Add(XeresProperty.infiniteBlades, true);
                PhotonNetwork.player.SetCustomProperties(hashtable3);
                this.addLINE("<color=#07522c> Infinite Blades Enabled! </color> ");
            }
        }
    }
}
