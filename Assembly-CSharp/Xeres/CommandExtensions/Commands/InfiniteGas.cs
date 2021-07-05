using UnityEngine;
namespace Xeres.CommandExtensions.Commands
{
    public class InfiniteGas : Command
    {
        private string[] names = { "infgas" };
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
                return "Toggles infinite gas";
            }
        }
        public override void executeCommand(string args)
        {
            
            if (RCextensions.returnBoolFromObject(PhotonNetwork.player.customProperties[XeresProperty.infiniteGas]))
            {
                ExitGames.Client.Photon.Hashtable hashtable3 = new ExitGames.Client.Photon.Hashtable();
                hashtable3.Add(XeresProperty.infiniteGas, false);
                PhotonNetwork.player.SetCustomProperties(hashtable3);
                this.addLINE("<color=#b31225> Infinite Gas Disabled! </color> ");
            }
            else
            {
                ExitGames.Client.Photon.Hashtable hashtable3 = new ExitGames.Client.Photon.Hashtable();
                hashtable3.Add(XeresProperty.infiniteGas, true);
                PhotonNetwork.player.SetCustomProperties(hashtable3);
                this.addLINE("<color=#07522c> Infinite Gas Enabled! </color> ");
            }
            
        }
    }
}
