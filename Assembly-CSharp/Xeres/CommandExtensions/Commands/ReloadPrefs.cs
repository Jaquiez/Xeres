using UnityEngine;
using System;
namespace Xeres.CommandExtensions.Commands
{
    public class ReloadPrefs : Command
    {
        private string[] names = { "reloadprefs" };
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
                return "Checks for any changes in Preferences.txt and changes them in game";
            }
        }
        public override void executeCommand(string args)
        {
            GameObject.Find("XeresManager").GetComponent<Xeres.UserPrefs.PropertyHandler>().setProperties();
            GameObject.Find("XeresManager").GetComponent<Xeres.UserPrefs.PropertyHandler>().loadProperties();
            addLINE("Prefs have been reloaded!");
        }
    }
}
