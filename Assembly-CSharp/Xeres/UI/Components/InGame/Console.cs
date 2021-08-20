using UnityEngine;
using System;
namespace Xeres.UI.Components.InGame
{
    public class Console : MonoBehaviour
    {

        Rect GUIRect;
        public Vector2 scrollPos = Vector2.zero;

        public void Start()
        {
            GUIRect = new Rect(Screen.width - 300f, Screen.height - 200f, 295f, 195f);
            scrollPos.y = int.MaxValue;
        }

        public void OnGUI()
        {
            if(Xeres.Tools.Logger.logs.Count>40)
            {
                Xeres.Tools.Logger.logs.RemoveAt(0);
            }
            GUI.Box(GUIRect,"");
            GUIRect = new Rect(Screen.width - 300f, Screen.height - 200f, 295f, 195f);
            GUILayout.BeginArea(GUIRect);
            scrollPos = GUILayout.BeginScrollView(scrollPos);
            foreach(string message in Xeres.Tools.Logger.logs)
            {
                GUILayout.Label(message);
            }
            GUILayout.EndScrollView();
            GUILayout.EndArea();
        }
    }
}
