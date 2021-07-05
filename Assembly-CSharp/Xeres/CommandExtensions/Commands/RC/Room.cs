using UnityEngine;
using System;
namespace Xeres.CommandExtensions.Commands
{
    public class Room : Command
    {
        private string[] names = { "room" };
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
                return "Changes room property. max: max players, time: time limit";
            }
        }
        public override void executeCommand(string args)
        {
            if (PhotonNetwork.isMasterClient)
            {
                if (args.StartsWith("max"))
                {
                    int num3 = Convert.ToInt32(Int32.Parse(args.Substring("max".Length)));
                    FengGameManagerMKII.instance.maxPlayers = num3;
                    PhotonNetwork.room.maxPlayers = num3;
                    FengGameManagerMKII.instance.photonView.RPC("Chat", PhotonTargets.All, new object[] { "<color=#a60d1a><b> Max players changed to " + args.Substring("max".Length) + "!</b></color>", "" });
                }
                else if (args.StartsWith("time"))
                {
                    FengGameManagerMKII.instance.addTime(Int32.Parse(args.Substring("time".Length)));
                    FengGameManagerMKII.instance.photonView.RPC("Chat", PhotonTargets.All, new object[] { "<color=#a60d1a><b>" + args.Substring("time".Length) + " seconds added to the clock.</b></color>", "" });
                }
            }
            else
            {
                this.addLINE("You are not master client.");
            }
        }
    }
}
