using UnityEngine;
using System;
namespace Xeres.UI.Components.MainMenu
{
    public class Tools : MonoBehaviour
    {
        Rect GUIRect;
        Rect GUIRect2;
        Rect GUIRect3;
        string[] buttonNames = { "Level Editor", "Custom Characters","Snapshot Reviewer"};
        public void Start()
        {
            GUIRect = new Rect(Screen.width - Screen.width * 3 / 4f, Screen.height - Screen.height * 7 / 9f, Screen.width * 1 / 2f, Screen.height * 5 / 9f);
            GUIRect2 = new Rect(Screen.width - Screen.width * 3 / 4f, Screen.height - Screen.height * 7 / 27f, Screen.width * 1 / 2f, Screen.height * 1 / 9f);
            GUIRect3 = new Rect(Screen.width - Screen.width * 3 / 4f, Screen.height - Screen.height * 7 / 9f, 1f+Screen.width * 1 / 2f, 20f+Screen.height * 5 / 9f);
        }
        public void OnGUI()
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), XeresAssetHandler.XeresTextures["Background"] as Texture2D);

            GUI.Box(GUIRect3,"");
            GUIStyle button = new GUIStyle("button");
            button.fontSize = Screen.width / 50;
            button.font = XeresAssetHandler.XeresAssets.Load("Moonrising") as Font;

            GUILayoutOption[] options = new GUILayoutOption[] {GUILayout.ExpandHeight(true),GUILayout.MaxHeight(Screen.height*1/12f) };
            GUILayout.BeginArea(GUIRect);

            GUILayout.BeginHorizontal();
            GUILayout.Space(10f);
            GUILayout.EndHorizontal();

            GUILayout.BeginVertical();
            GUIStyle label = new GUIStyle("label");
            label.font = XeresAssetHandler.XeresAssets.Load("Moonrising") as Font;
            label.alignment = TextAnchor.MiddleCenter;
            label.fontSize = Screen.width / 50;
            GUILayout.Label("Tools",label);
            GUILayout.Space(20f);
            foreach(string name in buttonNames)
            {
                if (GUILayout.Button(name,button,options))
                {
                    switch(name)
                    {
                        case "Level Editor":
                            FengGameManagerMKII.settings[0x40] = 0x65;
                            GameObject.Destroy(GameObject.Find("XeresUIManager"));
                            Application.LoadLevel(2);
                            break;
                        case "Custom Characters":
                            GameObject.Destroy(GameObject.Find("XeresUIManager"));
                            Application.LoadLevel("characterCreation");
                            break;
                        case "Snapshot Reviewer":
                            GameObject.Destroy(GameObject.Find("XeresUIManager"));
                            Application.LoadLevel("SnapShot");
                            break;
                        default:
                            break;
                    }
                }
                GUILayout.Space(20f);
            }
            GUILayout.EndVertical();
            GUILayout.EndArea();

            GUILayout.BeginArea(GUIRect);
            GUILayout.BeginHorizontal();
            GUILayout.Space(10f);
            GUILayout.EndHorizontal();
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Back", button))
            {
                GameObject.Find("XeresUIManager").AddComponent<MainMenuButtons>();
                GameObject.Find("XeresUIManager").AddComponent<PreferenceSetter>();
                GameObject.Find("XeresUIManager").AddComponent<Title>();
                GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<Tools>());
            }
            GUILayout.EndArea();
        }
    }
}
