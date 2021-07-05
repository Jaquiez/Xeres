using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Xeres.UI.Components.MainMenu
{
    public class CreateSingleGamePanel: MonoBehaviour
    {
        Rect GUIRect;
        Rect GUIRect2;
        Rect GUIRect3;
        Rect GUIRect4;
        string[] inputSettings;
        DictionaryEntry chosenMap;
        DictionaryEntry chosenDiff;
        DictionaryEntry chosenDayTime;
        DictionaryEntry chosenHero;
        List<string> levels = new List<string>();
        List<string> heroes = new List<string>();
        string[] difficulty;
        string[] dayTime;
        Vector2 scrollPos;
        Vector2 scrollPos2;
        Vector2 scrollPos3;
        Vector2 scrollPos4;
        public void Start()
        {
            GUIRect = new Rect(Screen.width - Screen.width * 3 / 4f - 5f, Screen.height - Screen.height * 7 / 9f-5f, 10f + Screen.width * 1 / 2f,10f+ Screen.height * 5 / 9f);
            GUIRect2 = new Rect(Screen.width - Screen.width * 3 / 4f, Screen.height - Screen.height * 7 / 9f, Screen.width * 1 / 4f, Screen.height * 5 / 9f);
            GUIRect3 = new Rect(Screen.width - Screen.width * 1 / 2f, Screen.height - Screen.height * 7 / 9f, Screen.width * 1 / 4f, Screen.height * 1 / 2f);
            GUIRect4 = new Rect(Screen.width - Screen.width * 3 / 4f, Screen.height - Screen.height * 7 / 27f, Screen.width * 1 / 2f, Screen.height * 1 / 9f);
            chosenMap = new DictionaryEntry(LevelInfo.getInfo("[S]City").name, false);
            chosenHero = new DictionaryEntry(HeroStat.getInfo("MIKASA").name, false);
            chosenDiff = new DictionaryEntry("Normal", false);
            chosenDayTime = new DictionaryEntry("Day", false);

            difficulty = new string[] { "Normal", "Hard", "Abnormal" };
            dayTime = new string[] { "Day", "Dawn", "Night" };
            foreach (LevelInfo info in LevelInfo.levels)
            {
                if (!info.name.Equals("Cage Fighting") && info.name.Contains("[S]"))
                    levels.Add(info.name);
            }
            foreach(string name in HeroStat.stats.Keys)
            {
                if(!name.Equals("CUSTOM_DEFAULT") && !name.Equals("CUSTOM_DEFAULT"))
                    heroes.Add(name);
            }
            heroes.Add("SET 1");
            heroes.Add("SET 2");
            heroes.Add("SET 3");
            scrollPos = Vector2.zero;
            scrollPos2 = Vector2.zero;
            scrollPos3 = Vector2.zero;
            scrollPos4 = Vector2.zero;

        }
        public void OnGUI()
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), XeresAssetHandler.XeresTextures["Background"] as Texture2D);
            GUI.Box(GUIRect, "");

            GUIStyle label = new GUIStyle("label");
            label.alignment = TextAnchor.UpperCenter;
            label.fontSize = Screen.width / 80;
            label.font = XeresAssetHandler.XeresAssets.Load("Moonrising") as Font;
            GUILayout.BeginArea(GUIRect);
            GUILayout.Label("Create Singeplayer Game", label, new GUILayoutOption[] { GUILayout.ExpandHeight(true) });
            GUILayout.EndArea();

            drawLeftSide();
            drawRightSide();

            GUIStyle button = new GUIStyle("button");
            button.fontSize = Screen.width / 80;
            button.font = XeresAssetHandler.XeresAssets.Load("Moonrising") as Font;
            GUILayout.BeginArea(GUIRect4);
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Start!", button))
            {

                switch (chosenDiff.Key.ToString().ToUpper())
                {
                    case "NORMAL":
                        chosenDiff.Key = 0;
                        break;
                    case "HARD":
                        chosenDiff.Key = 1;
                        break;
                    case "ABNORMAL":
                        chosenDiff.Key = 2;
                        break;
                    default:
                        chosenDiff.Key = 0;
                        break;
                }
                switch (chosenDayTime.Key.ToString().ToUpper())
                {
                    case "DAY":
                        IN_GAME_MAIN_CAMERA.dayLight = DayLight.Day;
                        break;
                    case "DAWN":
                        IN_GAME_MAIN_CAMERA.dayLight = DayLight.Dawn;
                        break;
                    case "NIGHT":
                        IN_GAME_MAIN_CAMERA.dayLight = DayLight.Night;
                        break;
                    default:
                        IN_GAME_MAIN_CAMERA.dayLight = DayLight.Day;
                        break;
                }
                IN_GAME_MAIN_CAMERA.difficulty = int.Parse(chosenDiff.Key.ToString());
                IN_GAME_MAIN_CAMERA.gametype = GAMETYPE.SINGLE;
                IN_GAME_MAIN_CAMERA.singleCharacter = chosenHero.Key.ToString().ToUpper();
                if (IN_GAME_MAIN_CAMERA.cameraMode == CAMERA_TYPE.TPS)
                {
                    Screen.lockCursor = true;
                }
                Screen.showCursor = false;
                FengGameManagerMKII.level = chosenMap.Key.ToString();
                Application.LoadLevel(LevelInfo.getInfo(chosenMap.Key.ToString()).mapName);
                GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<CreateSingleGamePanel>());
                GameObject.Find("XeresUIManager").AddComponent<LoadingScreen>();
            }
            if (GUILayout.Button("Back", button))
            {
                GameObject.Find("XeresUIManager").AddComponent<MainMenuButtons>();
                GameObject.Find("XeresUIManager").AddComponent<PreferenceSetter>();
                GameObject.Find("XeresUIManager").AddComponent<Title>();
                GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<CreateSingleGamePanel>());
            }
            GUILayout.EndHorizontal();
            GUILayout.EndArea();
        }
        public void drawLeftSide()
        {
            GUIStyle button = new GUIStyle("button");
            button.fontSize = Screen.width / 100;
            button.font = XeresAssetHandler.XeresAssets.Load("Moonrising") as Font;
            button.alignment = TextAnchor.MiddleCenter;

            GUIStyle label = new GUIStyle("label");
            label.alignment = TextAnchor.MiddleCenter;
            label.fontSize = Screen.width / 100;
            label.font = XeresAssetHandler.XeresAssets.Load("Moonrising") as Font;

            GUILayout.BeginArea(GUIRect2);

            GUILayout.BeginVertical();
            GUILayout.Space(Screen.height * 1 / 27f);

            GUILayout.Label("Map", label);
            //firstLevel = UITools.createDropdownMenu(levels.ToArray(), new Rect(Screen.width - Screen.width * 3 / 4f , Screen.height - Screen.height * 7 / 9f+Screen.height * 1 / 27f,Screen.width*1/4,Screen.height*1/12f),firstLevel);
            scrollPos = GUILayout.BeginScrollView(scrollPos, new GUILayoutOption[] { GUILayout.MaxHeight(Screen.height * 1 / 6f), GUILayout.Width(Screen.width * 1 / 4f - 5f) });
            chosenMap = UITools.createDropdownMenu(levels.ToArray(), (bool)chosenMap.Value, (string)chosenMap.Key, button);
            GUILayout.EndScrollView();

            GUILayout.Label("Difficulty", label);
            scrollPos2 = GUILayout.BeginScrollView(scrollPos2, new GUILayoutOption[] { GUILayout.MaxHeight(Screen.height * 1 / 12f), GUILayout.Width(Screen.width * 1 / 4f - 5f) });
            chosenDiff = UITools.createDropdownMenu(difficulty, (bool)chosenDiff.Value, (string)chosenDiff.Key, button);
            GUILayout.EndScrollView();

            GUILayout.Label("Time", label);
            scrollPos3 = GUILayout.BeginScrollView(scrollPos3, new GUILayoutOption[] { GUILayout.MaxHeight(Screen.height * 1 / 12f), GUILayout.Width(Screen.width * 1 / 4f - 5f) });
            chosenDayTime = UITools.createDropdownMenu(dayTime, (bool)chosenDayTime.Value, (string)chosenDayTime.Key, button);
            GUILayout.EndScrollView();
            GUILayout.EndVertical();
            GUILayout.EndArea();


        }

        public void drawRightSide()
        {
            GUILayout.BeginArea(GUIRect3);

            GUIStyle label = new GUIStyle("label");
            label.alignment = TextAnchor.MiddleCenter;
            label.fontSize = Screen.width / 90;
            label.font = XeresAssetHandler.XeresAssets.Load("Moonrising") as Font;

            GUIStyle button = new GUIStyle("button");
            button.fontSize = Screen.width / 100;
            button.font = XeresAssetHandler.XeresAssets.Load("Moonrising") as Font;
            button.alignment = TextAnchor.MiddleCenter;

            GUILayout.Space(Screen.height * 1 / 27f);

            GUILayout.Label("Choose Character", label);
            scrollPos4 = GUILayout.BeginScrollView(scrollPos4);
            chosenHero = UITools.createDropdownMenu(heroes.ToArray(), (bool)chosenHero.Value, (string)chosenHero.Key, button, new GUILayoutOption[] { GUILayout.Height(50f)});

            GUILayout.EndScrollView();

            GUILayout.EndArea();
        }
    }
}
