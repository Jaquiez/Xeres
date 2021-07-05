using UnityEngine;
using System;
namespace Xeres.CommandExtensions.Commands
{
    public class Spectate : Command
    {
        private string[] names = { "spectate" };
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
                return "Spectates an ID";
            }
        }
        public override void executeCommand(string args)
        {
            int num2 = Convert.ToInt32(args);
            GameObject[] array2 = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject gameObject4 in array2)
            {
                if (gameObject4.GetPhotonView().owner.ID == num2)
                {
                    Camera.main.GetComponent<IN_GAME_MAIN_CAMERA>().setMainObject(gameObject4);
                    Camera.main.GetComponent<IN_GAME_MAIN_CAMERA>().setSpectorMode(val: false);
                }
            }
        }
    }
}
