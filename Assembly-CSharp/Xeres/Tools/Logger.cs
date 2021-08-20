using System;
using System.Collections.Generic;
using UnityEngine;
namespace Xeres.Tools
{
    public static class Logger
    {
        public static List<String> logs = new List<string>();
        public static void addError(System.Object message)
        {
            try
            {
                logs.Add("<color=#ff0000>[ERROR]</color> " + message);
                GameObject.Find("XeresUIManager").GetComponent<Xeres.UI.Components.InGame.Console>().scrollPos.y = int.MaxValue;
            }
            catch(Exception e)
            {
                Debug.Log(message);
                Debug.LogError(e);
            }
            
        }
        public static void addWarning(string message)
        {
            try
            {
                logs.Add("<color=#de9516>[WARNING]</color> " + message);
                GameObject.Find("XeresUIManager").GetComponent<Xeres.UI.Components.InGame.Console>().scrollPos.y = int.MaxValue;
            }
            catch(Exception e)
            {
                Debug.Log(message);
                Debug.LogError(e);
            }

        }
        public static void addMessage(System.Object message)
        {
            try
            {
                logs.Add("<b>[MESSAGE]</b> " + (string)message);
                GameObject.Find("XeresUIManager").GetComponent<Xeres.UI.Components.InGame.Console>().scrollPos.y = int.MaxValue;
            }
            catch (Exception e)
            {
                Debug.Log(message);
                Debug.LogError(e);
            }       
        }       
        public static void addEvent(System.Object message)
        {
            try
            {
                logs.Add("<b>[EVENT]</b> " + (string)message);
                GameObject.Find("XeresUIManager").GetComponent<Xeres.UI.Components.InGame.Console>().scrollPos.y = int.MaxValue;
            }
            catch (Exception e)
            {
                Debug.Log(message);
                Debug.LogError(e);
            }
        }
    }
}
