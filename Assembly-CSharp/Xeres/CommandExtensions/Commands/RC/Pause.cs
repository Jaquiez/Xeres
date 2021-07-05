using UnityEngine;
using System;
namespace Xeres.CommandExtensions.Commands
{
    public class Pause : Command
    {
        private string[] names = { "pause" };
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
                return "[MC] Pauses the game";
            }
        }
        public override void executeCommand(string args)
        {
            if (PhotonNetwork.isMasterClient)
            {
                FengGameManagerMKII.instance.photonView.RPC("pauseRPC", PhotonTargets.All, new object[] { true });
                FengGameManagerMKII.instance.photonView.RPC("Chat", PhotonTargets.All, new object[] { "<color=#a60d1a><b> MasterClient has paused the game. </b></color>", "" });
            }
            else
            {
                this.addLINE("You are not master client.");
            }
        }
    }
}
