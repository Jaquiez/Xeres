using UnityEngine;
using System;
namespace Xeres.UI.Components.MainMenu
{
    public class XeresOptions : MonoBehaviour
    {
        Rect GUIRect = new Rect(Screen.width-Screen.width*.906f, Screen.height-Screen.height*7/9f, Screen.width* .8125f, Screen.height * 5 / 9f);
        Rect GUIRect4 = new Rect(Screen.width - Screen.width * .906f-5f, Screen.height - Screen.height * 7 / 9f - 5f, Screen.width * .8125f+10f, Screen.height * .05f+Screen.height * 5 / 9f+10f);
        Vector2 scrollPos = Vector2.zero;//600 +240
        ExitGames.Client.Photon.Hashtable settings;
        string[] sections;
        string currentSection;
        public void Start()
        {
            sections = new string[]{"Skin sets","Titan settings","Misc" };
            currentSection = sections[0];
        }
        public void OnGUI()
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), XeresAssetHandler.XeresTextures["Background"] as Texture2D);

            GUIStyle button = new GUIStyle("button");
            button.fontSize = Screen.width / 50;

            GUI.Box(GUIRect4, "");

            GUILayout.BeginArea(GUIRect);
            GUILayout.BeginHorizontal();
            foreach(string section in sections)
            {
                if(GUILayout.Button(section,button, new GUILayoutOption[] { GUILayout.Height(Screen.height*1/18f)}))
                {
                    currentSection = section;
                }
            }
            GUILayout.EndHorizontal();

            switch(currentSection)
            {
                case "Skin sets":
                    drawSkinSets();
                    break;
                case "Titan settings":
                    break;
                case "Misc":
                    break;
                default:
                    break;
            }
            GUILayout.EndArea();

        }
        private static void drawSkinSets()
        {
            GUILayout.Button("CLICK THIS!!!");
        }
    }
}
