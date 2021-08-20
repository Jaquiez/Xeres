using UnityEngine;
namespace Xeres.CommandExtensions.Commands
{
    public class Teleport : Command
    {
        private string[] names = { "tp","teleport" };
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
                return "teleports to target id";
            }
        }
        public override void executeCommand(string args)
        {
            GameObject[] objArray = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject thing in objArray)
            {
                var hero = thing.GetComponent<HERO>();
                if (hero.photonView.owner.ID == int.Parse(args))
                {
                    foreach (GameObject thing2 in objArray)
                    {
                        if (thing2.GetPhotonView().isMine)
                        {
                            var hero2 = thing2.GetComponent<HERO>();
                            hero2.transform.position = hero.transform.position;
                            return;
                        }
                    }
                }

            }

        }
    }
}
