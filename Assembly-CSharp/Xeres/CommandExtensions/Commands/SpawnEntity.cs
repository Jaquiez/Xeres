using UnityEngine;
namespace Xeres.CommandExtensions.Commands
{
    public class spawnEntity : Command
    {
        private string[] names = { "spawn" };
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
                return "[MC] Spawns an entity from a list of AoTTG elements";
            }
        }
        public override void executeCommand(string args)
        {
            if (PhotonNetwork.player.isMasterClient)
            {
                PhotonNetwork.Instantiate(args, Camera.main.transform.position, Camera.main.transform.rotation, 0);
            }
            else
            {
                this.addLINE("You're not master client :(");
            }
        }
    }
}
