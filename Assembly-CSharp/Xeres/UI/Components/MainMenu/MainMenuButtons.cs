using UnityEngine;
using System;
namespace Xeres.UI.Components.MainMenu
{
    public class MainMenuButtons : MonoBehaviour
    {
        Rect GUIRect = new Rect(1680, 720, 240, 360);
        string[] buttonNames = { "Singleplayer", "Multiplayer", "Options", "Tools", "Quit" };
        public void Start()
        {
            GUIRect = new Rect(Screen.width - Screen.width*.3f, Screen.height - Screen.height *2/3f, Screen.width * .3f, Screen.height*2/3f);
            buttonNames = new string[] { "Singleplayer", "Multiplayer", "Options", "Tools", "Quit" };
        }
        public void OnGUI()
        {
           // Xeres.UI.UITools.scaleUI();
            GUILayout.BeginArea(GUIRect);
            GUILayout.FlexibleSpace();
            GUIStyle button = new GUIStyle("button");//GUI.skin.button;
            button.fontSize = Screen.width/50;
            button.font = Xeres.UI.XeresAssetHandler.XeresAssets.Load("Moonrising") as Font;
            foreach (string name in buttonNames)
            {
                if (GUILayout.Button(name,button,new GUILayoutOption[] {GUILayout.Width(Screen.width * .3f), GUILayout.Height(.09f*Screen.height) }))
                {
                    switch (name)
                    {
                        case "Singleplayer":
                            //GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<MainMenu.MainMenuButtons>());
                            GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<MainMenuButtons>());
                            GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<Title>());
                        ;    GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<PreferenceSetter>());
                            GameObject.Find("XeresUIManager").AddComponent<CreateSingleGamePanel>();
                            Console.WriteLine("Singleplayer");
                            break;
                        case "Multiplayer":
                            GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<MainMenuButtons>());
                            GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<Title>());
                            GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<PreferenceSetter>());
                            GameObject.Find("XeresUIManager").AddComponent<MultiplayerPanel>();
                            Console.WriteLine("Multiplayer");
                            break;
                        case "Options":
                            //GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<MainMenu.MainMenuButtons>());
                            GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<MainMenuButtons>());
                            GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<Title>());
                            GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<PreferenceSetter>());
                            GameObject.Find("XeresUIManager").AddComponent<XeresOptions>();
                            Console.WriteLine("Options");
                            break;
                        case "Tools":
                            GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<MainMenuButtons>());
                            GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<Title>());
                            GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<PreferenceSetter>());
                            GameObject.Find("XeresUIManager").AddComponent<Tools>();
                            Console.WriteLine("Tools");
                            break;
                        case "Quit":
                            Console.WriteLine("Quit");
                            Application.Quit();
                            break;
                        default:
                            Console.WriteLine("Nothing?");
                            break;
                    }
                }
                
            }
            GUILayout.EndArea();
        }
    }
}
