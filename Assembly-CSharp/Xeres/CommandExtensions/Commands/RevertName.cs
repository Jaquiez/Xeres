using UnityEngine;
namespace Xeres.CommandExtensions.Commands
{
    public class RevertName : Command
    {
        private string[] names = { "revert" };
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
                return "Changes name to the one you saved to your Player Prferences";
            }
        }
        public override void executeCommand(string args)
        {
            Xeres.UserPrefs.PropertyHandler prophandler = GameObject.Find("XeresManager").GetComponent<Xeres.UserPrefs.PropertyHandler>();
            if(prophandler.XeresPropeties[XeresProperty.chatName].Equals(PhotonNetwork.player.customProperties[PhotonPlayerProperty.name]))
            {
                prophandler.XeresPropeties[XeresProperty.chatName] = PlayerPrefs.GetString("name").hexColor();
            }
            PhotonNetwork.player.customProperties[PhotonPlayerProperty.name] = PlayerPrefs.GetString("name");
            FengGameManagerMKII.instance.name = PlayerPrefs.GetString("name");
            PhotonNetwork.player.SetCustomProperties(new ExitGames.Client.Photon.Hashtable { { PhotonPlayerProperty.name, FengGameManagerMKII.instance.name } });
            this.addLINE("Name changed to: " + RCextensions.returnStringFromObject(PhotonNetwork.player.customProperties[PhotonPlayerProperty.name]).hexColor());
            //Gets our photon view and sends it as a setting
            GameObject[] array2 = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject go in array2)
            {
                if (go.GetPhotonView().isMine)
                {
                    FengGameManagerMKII.instance.photonView.RPC("labelRPC", PhotonTargets.All, go.GetPhotonView().viewID);
                }
            }
            
        }
    }
}
