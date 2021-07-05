using System;
using UnityEngine;
public abstract class Command
{
    private string[] names;
    public InRoomChat chatRoom = GameObject.Find("Chatroom").GetComponent<InRoomChat>();
    public void addLINE(string text)
    {
        chatRoom.addLINE("<color=#000000><b> ~| Xeres |~ </b></color>" + "" + text + "");
    }
    public abstract string [] commandNames
    {
            get;
    }
    public abstract string description
    {
        get;
    }

    public abstract void executeCommand(string args);
}

