using UnityEngine;
using System.IO;
using System.Diagnostics;
using System;

namespace Xeres.UI.Components.MainMenu
{
    public class StartUp : MonoBehaviour
    {
        Rect GUIRect = new Rect(Screen.width * .5f - 150f, Screen.height * .5f-100, 300f, 200);
        public void Start()
        {

        }
        public void OnGUI()
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), XeresAssetHandler.XeresTextures["loading1"] as Texture2D);
            switch (AutoUpdater.UpdateManager.status)
            {
                case UpdateStatus.Checking:
                    GUI.Box(GUIRect, "Checking for Update");
                    break;
                case UpdateStatus.Failed:
                    File.Delete(Environment.CurrentDirectory + @"\XeresUpdate.zip");
                    if (GUI.Button(new Rect(Screen.width * .5f - 150f, Screen.height * .5f - 50, 300f, 150), "Continue"))
                    {
                        //GameObject.Destroy("XeresUIManager");
                        GameObject.Find("XeresUIManager").AddComponent<PreferenceSetter>();
                        GameObject.Find("XeresUIManager").AddComponent<MainMenuButtons>();
                        GameObject.Find("XeresUIManager").AddComponent<Title>();
                        GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<StartUp>());
                        GameObject.Destroy(GameObject.Find("updater"));
                    }
                    GUI.Box(GUIRect, "Update failed?");
                    break;
                case UpdateStatus.NeedRestart:
                    File.Delete(Environment.CurrentDirectory + @"\XeresUpdate.zip");
                    if (GUI.Button(new Rect(Screen.width * .5f - 150f, Screen.height * .5f - 50, 300f, 150), "Restart"))
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo("Xeres.exe");
                        startInfo.WorkingDirectory = System.Environment.CurrentDirectory;
                        Process.Start(startInfo);
                        Application.Quit();
                    }
                    GUI.Box(GUIRect, "Update Complete, Restart your game!");
                    break;
                case UpdateStatus.Updated:
                    GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<StartUp>());
                    break;
                case UpdateStatus.Updating:
                    GUI.Box(GUIRect, "Updating Game");
                    break;
                default:
                    break;
            }
        }
    }
}
