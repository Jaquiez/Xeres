using UnityEngine;
using System;
using System.IO;
using ExitGames.Client.Photon;
using System.Collections.Generic;
using System.Collections;

namespace Xeres.UI.Components.MainMenu
{
    public class XeresOptions : MonoBehaviour
    {
        Rect GUIRect = new Rect(Screen.width-Screen.width*.906f, Screen.height-Screen.height*7/9f, Screen.width* .8125f, Screen.height * 5 / 9f);
        Rect GUIRect2 = new Rect(Screen.width - Screen.width * .906f, Screen.height - Screen.height * 2 / 9f, Screen.width * .8125f, Screen.height * .05f);
        Rect GUIRect4 = new Rect(Screen.width - Screen.width * .906f-5f, Screen.height - Screen.height * 7 / 9f - 5f, Screen.width * .8125f+10f, Screen.height * .05f+Screen.height * 5 / 9f+10f);
        private static Vector2 scrollPos = Vector2.zero;//600 +240
        ExitGames.Client.Photon.Hashtable settings;
        string[] sections;
        private static string skinDirectory;
        private static ExitGames.Client.Photon.Hashtable currentSkinSet;
        private static string currentSetName;
        private static string currentSection;
        private static string currentSkinSection;

        private static Setting humanSetting;
        public void Start()
        {
            sections = new string[] { "Skin sets", "Titan settings", "Misc" };
            currentSection = sections[0];
            skinDirectory = Application.dataPath + @"/Config/HumanSkinSets/";
            foreach (Setting setting in GameObject.Find("XeresManager").GetComponent<Options.SettingHandler>().settings)
            {
                if (setting.name.Equals("HumanSet"))
                {
                    currentSkinSet = setting.userData;
                    humanSetting = setting;
                }
            }
            currentSection = "Skin sets";
            currentSkinSection = "Human";
            currentSetName = "SkinSet1";
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


            GUILayout.BeginArea(GUIRect2);
            GUILayout.Space(5f);
            GUILayout.BeginHorizontal();
            GUILayoutOption[] options = new GUILayoutOption[] { GUILayout.ExpandHeight(true) };
            if(GUILayout.Button("Save", options))
            {
                foreach (Setting setting in GameObject.Find("XeresManager").GetComponent<Options.SettingHandler>().settings)
                {
                    switch (setting.name)
                    {
                        case "HumanSet":
                            setting.saveHashtableToFile(currentSkinSet, currentSetName);
                            break;
                        default:
                            break;
                    }
                }
            }
            if(GUILayout.Button("Load", options))
            {
                foreach(Setting setting in GameObject.Find("XeresManager").GetComponent<Options.SettingHandler>().settings)
                {
                    switch (setting.name)
                    {
                        case "HumanSet":
                            currentSkinSet = setting.getTempUserData(currentSetName);
                            break;
                        default:
                            break;
                    }
                }
            }
            if(GUILayout.Button("Back",options ))
            {
                GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<XeresOptions>());
                GameObject.Find("XeresUIManager").AddComponent<PreferenceSetter>();
                GameObject.Find("XeresUIManager").AddComponent<MainMenuButtons>();
                GameObject.Find("XeresUIManager").AddComponent<Title>();
            }
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }
        private static void drawSkinSets()
        {
            GUILayout.Space(5);
            GUILayout.BeginHorizontal();
            foreach(string section in new[] { "Human","Titan","Map"})
            {
                if(GUILayout.Button(section))
                {
                    currentSkinSection = section;
                }
            }
            GUILayout.EndHorizontal();
            switch (currentSkinSection)
            {
                case "Human":
                    drawHumanSkinSets();
                    break;
                case "Titan":
                    break;
                case "Map":
                    break;
                default:
                    break;
            }
        }

        private static void drawHumanSkinSets()
        {
            List<string> skinsets = new List<string>(Directory.GetFiles(skinDirectory));
            for(int k =0; k<skinsets.ToArray().Length; k++)
            {
                if (!skinsets[k].EndsWith(".txt"))
                    skinsets.Remove(skinsets[k]);
                else
                {
                    skinsets[k] = skinsets[k].Replace(".txt", "");
                    skinsets[k] = skinsets[k].Substring(1 + skinsets[k].LastIndexOf("/"));
                }
            }
            GUILayout.Space(5f);
            GUILayout.BeginHorizontal();
            if(GUILayout.Button(currentSetName))
            {
                if (skinsets.IndexOf(currentSetName) + 1 < skinsets.ToArray().Length)
                {
                    currentSetName = skinsets[skinsets.IndexOf(currentSetName) + 1];
                    currentSkinSet = humanSetting.getTempUserData(currentSetName);
                }
                else
                {
                    currentSetName = skinsets[0];
                    currentSkinSet = humanSetting.getTempUserData(currentSetName);
                }

            }
            if(GUILayout.Button("Create New Set"))
            {
                humanSetting.createEmptyFile("SkinSet" + (skinsets.ToArray().Length+1));
                currentSetName = "SkinSet" + (skinsets.ToArray().Length + 1);
            }
            GUILayout.EndHorizontal();
            GUILayout.Space(10f);
            var keys = currentSkinSet.StripToStringKeys();

            GUIStyle label = new GUIStyle("label");
            label.alignment = TextAnchor.MiddleCenter;
            scrollPos =GUILayout.BeginScrollView(scrollPos);
            foreach(var key in keys.Keys)
            {
                GUILayout.BeginHorizontal();               
                GUILayout.Label(key.ToString(),label, new GUILayoutOption[] { GUILayout.Width(100f) });
                currentSkinSet[key] = GUILayout.TextField(currentSkinSet[key].ToString(), new GUILayoutOption[] { });
                GUILayout.EndHorizontal();
                GUILayout.Space(10f);
            }
            GUILayout.EndScrollView();
        }
    }
}
