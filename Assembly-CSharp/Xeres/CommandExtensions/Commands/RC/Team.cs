using UnityEngine;
namespace Xeres.CommandExtensions.Commands
{
	public class Team : Command
	{
		private string[] names = { "team" };
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
                return "Changes team in team gamemode";
            }
        }
        public override void executeCommand(string args)
		{            
            if (RCSettings.teamMode == 1)
            {
                if ((args == "1") || (args == "cyan"))
                {
                    FengGameManagerMKII.instance.photonView.RPC("setTeamRPC", PhotonNetwork.player, new object[] { 1 });
                    this.addLINE("<color=#00FFFF>You have joined team cyan.</color>");
                    foreach (GameObject obj2 in GameObject.FindGameObjectsWithTag("Player"))
                    {
                        if (obj2.GetPhotonView().isMine)
                        {
                            obj2.GetComponent<HERO>().markDie();
                            obj2.GetComponent<HERO>().photonView.RPC("netDie2", PhotonTargets.All, new object[] { -1, "Team Switch" });
                        }
                    }
                }
                else if ((args == "2") || (args == "magenta"))
                {
                    FengGameManagerMKII.instance.photonView.RPC("setTeamRPC", PhotonNetwork.player, new object[] { 2 });
                    this.addLINE("<color=#FF00FF>You have joined team magenta.</color>");
                    foreach (GameObject obj3 in GameObject.FindGameObjectsWithTag("Player"))
                    {
                        if (obj3.GetPhotonView().isMine)
                        {
                            obj3.GetComponent<HERO>().markDie();
                            obj3.GetComponent<HERO>().photonView.RPC("netDie2", PhotonTargets.All, new object[] { -1, "Team Switch" });
                        }
                    }
                }
                else if ((args == "0") || (args == "individual"))
                {
                    FengGameManagerMKII.instance.photonView.RPC("setTeamRPC", PhotonNetwork.player, new object[] { 0 });
                    this.addLINE("<color=#00FF00>You have joined individuals.</color>");
                    foreach (GameObject obj4 in GameObject.FindGameObjectsWithTag("Player"))
                    {
                        if (obj4.GetPhotonView().isMine)
                        {
                            obj4.GetComponent<HERO>().markDie();
                            obj4.GetComponent<HERO>().photonView.RPC("netDie2", PhotonTargets.All, new object[] { -1, "Team Switch" });
                        }
                    }
                }
                else
                {
                    this.addLINE("Invalid team code. Accepted values are 0,1, and 2.");
                }
            }
            else
            {
                this.addLINE("Teams are locked or disabled.");
            }
        }
	}
}
