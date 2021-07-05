using UnityEngine;
using System;
using System.IO;
using System.Diagnostics;
namespace Xeres.UI.Components.MainMenu
{
    public class PreferenceSetter :MonoBehaviour
    {
        Rect GUIRect = new Rect(0, 0, 500, 300);
        public void Start()
        {
            FengGameManagerMKII.nameField = PlayerPrefs.GetString("name", string.Empty);
            LoginFengKAI.player.guildname = PlayerPrefs.GetString("guildname", string.Empty);

        }
        public void OnGUI()
        {
            GUI.Box(GUIRect, "");
            GUILayout.BeginArea(GUIRect);
            GUIStyle label = new GUIStyle("label");//GUI.skin.label;
            label.fontSize = 25;
            label.alignment = TextAnchor.MiddleCenter;
            GUILayout.Label("Preferences",label, new GUILayoutOption[] {}) ;

            GUILayout.BeginHorizontal(GUILayout.MaxWidth(485f));
            GUILayout.Space(5f);
            GUILayout.Label("Name:");
            FengGameManagerMKII.nameField = GUILayout.TextField(FengGameManagerMKII.nameField, new GUILayoutOption[] {GUILayout.Width(430f)});
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal(GUILayout.MaxWidth(485f));
            GUILayout.Space(5f);
            GUILayout.Label("Guild:");
            LoginFengKAI.player.guildname = GUILayout.TextField(LoginFengKAI.player.guildname, new GUILayoutOption[] { GUILayout.Width(430f) });
            GUILayout.EndHorizontal();
           
            GUILayout.Space(100f);
            GUILayoutOption[] options = new GUILayoutOption[] { GUILayout.ExpandHeight(true) };
            GUIStyle button = new GUIStyle("button");
            button.fontSize = 20;
            button.alignment = TextAnchor.MiddleCenter;
            if (GUILayout.Button("Open Preferences", button, new GUILayoutOption[] { GUILayout.ExpandHeight(true), GUILayout.MaxWidth(492f) }))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("notepad.exe", Environment.CurrentDirectory + @"/Preferences.txt");
                Process.Start(startInfo);
            }           
            GUILayout.BeginHorizontal(GUILayout.MaxWidth(492f));
            if (GUILayout.Button("Save",button,options))
            {
                PlayerPrefs.SetString("name", FengGameManagerMKII.nameField);
                PlayerPrefs.SetString("guildname", LoginFengKAI.player.guildname);
                GameObject.Find("XeresManager").GetComponent<Xeres.UserPrefs.PropertyHandler>().setProperties();
            }
            if(GUILayout.Button("Load",button,options))
            {
                FengGameManagerMKII.nameField = PlayerPrefs.GetString("name", string.Empty);
                LoginFengKAI.player.guildname = PlayerPrefs.GetString("guildname", string.Empty);
            }
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }
    }
}
