using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Xeres.UI.Components.MainMenu
{
    public class CreateMultiGamePanel : MonoBehaviour
    {
        Rect GUIRect;
        Rect GUIRect2;
        Rect GUIRect3;
        Rect GUIRect4;
        string[] inputSettings;
        DictionaryEntry chosenMap;
        DictionaryEntry chosenDiff;
        DictionaryEntry chosenDayTime;
        List<string> levels = new List<string>();
        string[] difficulty;
        string[] dayTime;
        Vector2 scrollPos;
        Vector2 scrollPos2;
        Vector2 scrollPos3;
        string serverName;
        string serverTime;
        string playerCount;
        string pass = "";
        public void Start()
        {
            GUIRect = new Rect(Screen.width - Screen.width * 3 / 4f - 5f, Screen.height - Screen.height * 7 / 9f - 5f, 10f + Screen.width * 1 / 2f, 10f + Screen.height * 5 / 9f);
            GUIRect2 = new Rect(Screen.width - Screen.width * 3 / 4f, Screen.height - Screen.height * 7 / 9f, Screen.width * 1 / 4f, Screen.height * 5 / 9f);
            GUIRect3 = new Rect(Screen.width - Screen.width * 1 / 2f, Screen.height - Screen.height * 7 / 9f, Screen.width * 1 / 4f, Screen.height * 5 / 9f);
            GUIRect4 = new Rect(Screen.width - Screen.width * 3/4f, Screen.height - Screen.height * 7 / 27f, Screen.width * 1 / 2f, Screen.height * 1 / 9f);
            chosenMap = new DictionaryEntry(LevelInfo.getInfo("The City").name, false);
            chosenDiff = new DictionaryEntry("Normal", false);
            chosenDayTime = new DictionaryEntry("Day", false);
            serverName = "| Xeres |";
            serverTime = "99999";
            playerCount = "8";
            pass = "";

            difficulty = new string[] {"Normal","Hard","Abnormal" };
            dayTime = new string[] { "Day", "Dawn", "Night" };
            foreach (LevelInfo info in LevelInfo.levels)
            {
                if(!info.name.Equals("Cage Fighting"))
                    levels.Add(info.name);
            }
            scrollPos = Vector2.zero;
            scrollPos2 = Vector2.zero;
            scrollPos3 = Vector2.zero;
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
            GUILayout.Label("Create Game",label, new GUILayoutOption[] {GUILayout.ExpandHeight(true)});
            GUILayout.EndArea();

            drawLeftSide();
            drawRightSide();

            GUIStyle button = new GUIStyle("button");
            button.fontSize = Screen.width / 80;
            button.font = XeresAssetHandler.XeresAssets.Load("Moonrising") as Font;
            GUILayout.BeginArea(GUIRect4);
            GUILayout.BeginHorizontal();
            if(GUILayout.Button("Start!",button))
            {
                if(pass.Length>0)
                {
                    pass = new SimpleAES().Encrypt(pass);
                }
                PhotonNetwork.CreateRoom(string.Concat(new object[] { serverName, "`", chosenMap.Key, "`", chosenDiff.Key.ToString().ToLower(), "`", serverTime, "`", chosenDayTime.Key.ToString().ToLower(), "`", pass, "`" + UnityEngine.Random.Range(0, 0xc350) }), true, true, int.Parse(playerCount));
                PhotonNetwork.offlineMode = false;
            }
            if (GUILayout.Button("Back",button))
            {
                GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<CreateMultiGamePanel>());
                GameObject.Find("XeresUIManager").AddComponent<MultiplayerPanel>();
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
            scrollPos = GUILayout.BeginScrollView(scrollPos, new GUILayoutOption[] { GUILayout.MaxHeight(Screen.height * 1 / 6f),GUILayout.Width(Screen.width * 1 / 4f-5f) });
            chosenMap = UITools.createDropdownMenu(levels.ToArray(), (bool)chosenMap.Value, (string)chosenMap.Key,button);
            GUILayout.EndScrollView();

            GUILayout.Label("Difficulty", label);
            scrollPos2 = GUILayout.BeginScrollView(scrollPos2, new GUILayoutOption[] { GUILayout.MaxHeight(Screen.height * 1 / 12f), GUILayout.Width(Screen.width * 1 / 4f - 5f) });
            chosenDiff = UITools.createDropdownMenu(difficulty, (bool)chosenDiff.Value, (string)chosenDiff.Key,button);
            GUILayout.EndScrollView();

            GUILayout.Label("Time", label);
            scrollPos3 = GUILayout.BeginScrollView(scrollPos3, new GUILayoutOption[] { GUILayout.MaxHeight(Screen.height * 1 / 12f), GUILayout.Width(Screen.width * 1 / 4f - 5f) });
            chosenDayTime = UITools.createDropdownMenu(dayTime, (bool)chosenDayTime.Value, (string)chosenDayTime.Key,button);
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

            GUIStyle textField = new GUIStyle("TextField");
            textField.alignment = TextAnchor.LowerCenter;
            textField.fontSize = Screen.width / 90;
            GUILayout.Space(Screen.height * 1 / 27f);

            GUILayoutOption[] option = new GUILayoutOption[] { GUILayout.Height(Screen.height * 1 / 27f) };
            GUILayout.Label("Name",label);
            serverName = GUILayout.TextField(serverName, textField, option);
            GUILayout.Space(Screen.height * 1 / 27f);
            GUILayout.Label("Max Time",label);
            serverTime = GUILayout.TextField(Regex.Replace(serverTime, "[\\D]",replacement:""),textField,option);
            GUILayout.Space(Screen.height * 1 / 27f);
            GUILayout.Label("Max Players",label);
            playerCount = GUILayout.TextField(Regex.Replace(playerCount, "[\\D]", replacement: ""),textField,option);
            GUILayout.Space(Screen.height * 1 / 27f);
            GUILayout.Label("Password",label);
            pass = GUILayout.TextField(pass,textField,option);
            GUILayout.EndArea();
        }
    }
}
