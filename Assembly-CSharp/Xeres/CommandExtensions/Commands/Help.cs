using UnityEngine;
using System;
using System.Collections.Generic;

namespace Xeres.CommandExtensions.Commands
{
    public class Help : Command
    {
        private string[] names = { "help" };
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
                return "Displaying a list of commands (probably doing this right now)";
            }
        }
        public override void executeCommand(string args)
        {
            List<Command> commands = new List<Command>(CommandHandler.commandList);
            int pageNumber = args == string.Empty ? 0 : Int32.Parse(args);
            int maxVal = pageNumber * 5 + 5 > commands.ToArray().Length ? commands.ToArray().Length : pageNumber * 5 + 5; 

            if (commands.ToArray().Length < pageNumber*5) return;

            InRoomChat room = GameObject.Find("Chatroom").GetComponent<InRoomChat>();

            room.addLINE("<color=#000000> <b>                         ~ COMMANDS ~                           </b> </color>");
            for (int k=5*pageNumber;k<maxVal;k++)
            {
                if(commands[k] != null)
                {
                    room.addLINE("<color=#550011>" + commands[k].commandNames[0] + "</color>: " + commands[k].description);
                }
            }

            if(commands.ToArray().Length > (1 + pageNumber) * 5)
                room.addLINE("Do /help " + (1 + pageNumber) + " to see more commands :)");

        }
    }
}
