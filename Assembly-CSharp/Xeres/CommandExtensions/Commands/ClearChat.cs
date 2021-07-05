using UnityEngine;
using System;
namespace Xeres.CommandExtensions.Commands
{
    public class ClearChat : Command
    {
        private string[] names = { "clear" };
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
                return "Clears chat";
            }
        }
        public override void executeCommand(string args)
        {
            for (int k = 0; k < 50; k++)
            {
                this.addLINE("");
            }
            this.addLINE("Chat has been cleared...");
        }
    }
}
