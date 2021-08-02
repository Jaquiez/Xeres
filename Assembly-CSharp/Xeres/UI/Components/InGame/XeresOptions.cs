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
        private static string currentSection;       
        private static string currentSkinSection;
        //Human Set variables
        private static string currentHumanSetName;
        private static Setting humanSetting;
        //Titan Set variables
        private static string currentTitanSetName;
        private static Setting titanSetting;
        //overall
        public static string currentSetName;
        public void Start()
        {
            sections = new string[] { "Skin sets", "Titan settings", "Misc" };
            currentSection = sections[0];
            skinDirectory = Application.dataPath + @"/Config/SkinSets/HumanSkinSets/";
            foreach (Setting setting in GameObject.Find("XeresManager").GetComponent<Options.SettingHandler>().settings)
            {
                switch(setting.name)
                {
                    case "HumanSet":
                        currentSkinSet = setting.userData;
                        humanSetting = setting;
                        currentHumanSetName = "SkinSet1";
                        break;
                    case "TitanSet":
                        titanSetting = setting;
                        currentTitanSetName = "SkinSet1";
                        break;
                }
            }
            currentSection = "Skin sets";
            currentSkinSection = "Human";

            currentSetName = currentHumanSetName;
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
                case "Multiplayer Settings":
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
                    if (currentSkinSection + "Set" == setting.name)
                    {
                        setting.saveHashtableToFile(currentSkinSet, currentSetName);
                    }
                    switch (setting.name)
                    {
                        case "HumanSet":
                            break;
                        case "TitanSet":
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
                        case "TitanSet":
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
                    switch (currentSkinSection)
                    {
                        case "Human":
                            currentSkinSet = humanSetting.getTempUserData(currentHumanSetName);
                            break;
                        case "Titan":
                            currentSkinSet = titanSetting.getTempUserData(currentTitanSetName);
                            break;
                        case "Map":
                            break;
                        default:
                            break;
                    }
                }
            }
            GUILayout.EndHorizontal();
            switch (currentSkinSection)
            {
                case "Human":
                    currentSetName = currentHumanSetName;
                    //currentSkinSet = humanSetting.getTempUserData(currentHumanSetName);
                    skinDirectory = humanSetting.configDirectory;
                    drawCurrentSkinSet(humanSetting);
                    currentHumanSetName = currentSetName;
                    break;
                case "Titan":
                    currentSetName = currentTitanSetName;
                    //currentSkinSet = titanSetting.getTempUserData(currentTitanSetName);
                    skinDirectory = titanSetting.configDirectory;
                    drawCurrentSkinSet(titanSetting);
                    currentTitanSetName = currentSetName;
                    break;
                case "Map":
                    break;
                default:
                    break;
            }
        }
        private static void drawCurrentSkinSet(Setting setting)
        {
            List<string> skinsets = new List<string>(Directory.GetFiles(skinDirectory));
            for (int k = 0; k < skinsets.ToArray().Length; k++)
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
            if (GUILayout.Button(currentSetName))
            {
                Console.WriteLine(currentSetName);
                if (skinsets.IndexOf(currentSetName) + 1 < skinsets.ToArray().Length)
                {
                    currentSetName = skinsets[skinsets.IndexOf(currentSetName) + 1];
                    currentSkinSet = setting.getTempUserData(currentSetName);
                }
                else
                {
                    currentSetName = skinsets[0];
                    currentSkinSet = setting.getTempUserData(currentSetName);
                }
                Console.WriteLine(currentSetName);
            }
            if (GUILayout.Button("Create New Set"))
            {
                currentSetName = "SkinSet" + (skinsets.ToArray().Length + 1);
                setting.createEmptyFile("SkinSet" + (skinsets.ToArray().Length + 1));
            }
            GUILayout.EndHorizontal();
            GUILayout.Space(10f);
            var keys = currentSkinSet.StripToStringKeys();

            GUIStyle label = new GUIStyle("label");
            label.alignment = TextAnchor.MiddleCenter;
            scrollPos = GUILayout.BeginScrollView(scrollPos);
            foreach (var key in keys.Keys)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(key.ToString(), label, new GUILayoutOption[] { GUILayout.Width(100f) });
                string replace = "";
                if(currentSkinSet[key].ToString().Contains(","))
                {
                    string[] skins = currentSkinSet[key].ToString().Split(',');
                    for (int k=0; k<skins.Length;k++)
                    {
                        if (!(skins[k] == ""))
                        {
                            skins[k] = GUILayout.TextField(skins[k], new GUILayoutOption[] { });
                            //currentSkinSet[key] = currentSkinSet[key].ToString().Replace(currentSkinSet[key].ToString().Split(',')[k], skins[k]);
                        }
                        else
                        {
                            skins[k] = GUILayout.TextField(skins[k], new GUILayoutOption[] { });
                            //if (!(skins[k] == "")) { currentSkinSet[key] = currentSkinSet[key].ToString().Replace(currentSkinSet[key].ToString().Split(',')[k], skins[k]); }
                        }
                        replace += skins[k] + ",";
                    }
                    replace = replace.Substring(0, replace.LastIndexOf(','));
                    Console.WriteLine(replace);
                    currentSkinSet[key] = replace;
                }
                else
                {
                    currentSkinSet[key] = GUILayout.TextField(currentSkinSet[key].ToString(), new GUILayoutOption[] { });
                }

                GUILayout.EndHorizontal();
                GUILayout.Space(10f);
            }
            GUILayout.EndScrollView();
        }
        /*
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
            if(GUILayout.Button(currentHumanSetName))
            {
                if (skinsets.IndexOf(currentHumanSetName) + 1 < skinsets.ToArray().Length)
                {
                    currentHumanSetName = skinsets[skinsets.IndexOf(currentHumanSetName) + 1];
                    currentSkinSet = humanSetting.getTempUserData(currentHumanSetName);
                }
                else
                {
                    currentHumanSetName = skinsets[0];
                    currentSkinSet = humanSetting.getTempUserData(currentHumanSetName);
                }

            }
            if(GUILayout.Button("Create New Set"))
            {
                humanSetting.createEmptyFile("SkinSet" + (skinsets.ToArray().Length+1));
                currentHumanSetName = "SkinSet" + (skinsets.ToArray().Length + 1);
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
        }*/

    }
}
