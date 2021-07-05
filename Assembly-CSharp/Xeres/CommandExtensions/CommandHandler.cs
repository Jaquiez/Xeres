using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
namespace Xeres.CommandExtensions
{
    public class CommandHandler : Photon.MonoBehaviour
    {
        public static IEnumerable<Command> commandList;
        public void Start()
        {
            commandList = getCommandList();
        }
        public static IEnumerable<Command> getCommandList()
        {
            //Got this implementation from a Stack Overflow post
            IEnumerable<Command> exporters = typeof(Command) //Exporters is IEnumerable of Command Types
                .Assembly.GetTypes() //Gets all Command type classes that are not abstract
                .Where(t => t.IsSubclassOf(typeof(Command)) && !t.IsAbstract) 
                .Select(t => (Command)Activator.CreateInstance(t)); //Creates an Instance of each Command  when it adds it to exporter
            return exporters; 
        }

        public void handleCommand(string inputLine)
        {
            foreach(Command cmd in commandList)
            {      
                foreach(string cmdname in cmd.commandNames)
                {
                    if (cmdname.ToLower().Equals(inputLine.Split(' ')[0].Substring(1).ToLower()))
                    {
                        string args = inputLine.Split(' ').Length > 1 ? inputLine.Substring(1 + inputLine.Split(' ')[0].Length) : inputLine.Substring(inputLine.Split(' ')[0].Length);
                        cmd.executeCommand(args);
                        return;
                    }
                }
            }

            InRoomChat room = GameObject.Find("Chatroom").GetComponent<InRoomChat>();
            room.addLINE("Not a command, please use /help to see a full list of commands :)");
        }

    }
}
