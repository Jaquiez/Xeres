using UnityEngine;
namespace Xeres.CommandExtensions.Commands
{
    public class TitanScatter : Command
    {
        private string[] names = { "scatter" };
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
                return "Scatters the titans positions randomly";
            }
        }
        public override void executeCommand(string args)
        {
            if (PhotonNetwork.player.isMasterClient)
            {
                GameObject[] objArray = GameObject.FindGameObjectsWithTag("titan");
                foreach (GameObject bigdummy in objArray)
                {
                    Vector3 position = new Vector3(UnityEngine.Random.Range(-400f, 400f), 0f, UnityEngine.Random.Range(-400f, 400f));
                    Quaternion rotation = new Quaternion(0f, 0f, 0f, 1f);
                    bigdummy.transform.position = position;
                    bigdummy.transform.rotation = rotation;
                }
                object[] parameters = new object[] { "<color=#a60d1a> ~TITANS HAVE BEEN SCATTERED~ </color>", "<b><color=#000000>Xeres</color></b>" };
                FengGameManagerMKII.instance.photonView.RPC("Chat", PhotonTargets.All, parameters);
            }
            else
            {
                this.addLINE("YOU'RE NOT MASTERCLIENT DAWG!");
            }
        }
    }
}
