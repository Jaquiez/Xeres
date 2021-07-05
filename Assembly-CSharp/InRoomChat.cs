//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using ExitGames.Client.Photon;
using Photon;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InRoomChat : Photon.MonoBehaviour
{
    public Xeres.UserPrefs.PropertyHandler propHandler = GameObject.Find("XeresManager").GetComponent<Xeres.UserPrefs.PropertyHandler>();
    private bool AlignBottom = true;
    public static readonly string ChatRPC = "Chat";
    public static Rect GuiRect = new Rect(0f, 100f, 300f, 470f);
    public static Rect GuiRect2 = new Rect(30f, 575f, 300f, 25f);
    private string inputLine = string.Empty;
    public bool IsVisible = true;
    public static List<string> messages = new List<string>();
    //private Vector2 scrollPos = Vector2.zero;
    private float deltaTime;
    public Vector2 scrollPosition = Vector2.zero; 
    private int maxLines = 50;
    public void addLINE(string newLine)
    {
        messages.Add(newLine);
        while (messages.Count > maxLines)
            messages.RemoveAt(0);
        scrollPosition.y = int.MaxValue;
    }
    public void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }
    private void ShowFPS()
    {
        Rect position = new Rect(160f, 1f, 100f, 30f);
        int num = (int)Math.Round(1f / deltaTime);
        GUI.Label(position, $"FPS: {num}");
    }

    public void AddLine(string newLine)
    {
        messages.Add(newLine);
        scrollPosition.y = int.MaxValue;
    }

    public void OnGUI()
    {
        int num4;
        if (!this.IsVisible || (PhotonNetwork.connectionStateDetailed != PeerStates.Joined))
        {
            return;
        }
        if (Event.current.type == EventType.KeyDown)
        {
            if ((((Event.current.keyCode == KeyCode.Tab) || (Event.current.character == '\t')) && !IN_GAME_MAIN_CAMERA.isPausing) && (FengGameManagerMKII.inputRC.humanKeys[InputCodeRC.chat] != KeyCode.Tab))
            {
                Event.current.Use();
                goto Label_219C;
            }
        }
        else if ((Event.current.type == EventType.KeyUp) && (((Event.current.keyCode != KeyCode.None) && (Event.current.keyCode == FengGameManagerMKII.inputRC.humanKeys[InputCodeRC.chat])) && (GUI.GetNameOfFocusedControl() != "ChatInput")))
        {
            this.inputLine = string.Empty;
            GUI.FocusControl("ChatInput");
            goto Label_219C;
        }
        if ((Event.current.type == EventType.KeyDown) && ((Event.current.keyCode == KeyCode.KeypadEnter) || (Event.current.keyCode == KeyCode.Return)))
        {
            if (!string.IsNullOrEmpty(this.inputLine))
            {
                string str2;
                if (this.inputLine == "\t")
                {
                    this.inputLine = string.Empty;
                    GUI.FocusControl(string.Empty);
                    return;
                }
                if (FengGameManagerMKII.RCEvents.ContainsKey("OnChatInput"))
                {
                    string key = (string) FengGameManagerMKII.RCVariableNames["OnChatInput"];
                    if (FengGameManagerMKII.stringVariables.ContainsKey(key))
                    {
                        FengGameManagerMKII.stringVariables[key] = this.inputLine;
                    }
                    else
                    {
                        FengGameManagerMKII.stringVariables.Add(key, this.inputLine);
                    }
                    ((RCEvent) FengGameManagerMKII.RCEvents["OnChatInput"]).checkEvent();
                }
                if (!this.inputLine.StartsWith("/"))
                {
                    str2 = propHandler.XeresPropeties.ContainsKey(XeresProperty.chatName) ? RCextensions.returnStringFromObject(propHandler.XeresPropeties[XeresProperty.chatName]).hexColor() : RCextensions.returnStringFromObject(PhotonNetwork.player.customProperties[PhotonPlayerProperty.name]).hexColor();
                    if (str2 == string.Empty)
                    {
                        str2 = RCextensions.returnStringFromObject(PhotonNetwork.player.customProperties[PhotonPlayerProperty.name]).hexColor();
                        if (PhotonNetwork.player.customProperties[PhotonPlayerProperty.RCteam] != null)
                        {
                            if (RCextensions.returnIntFromObject(PhotonNetwork.player.customProperties[PhotonPlayerProperty.RCteam]) == 1)
                            {
                                str2 = "<color=#00FFFF>" + str2 + "</color>";
                            }
                            else if (RCextensions.returnIntFromObject(PhotonNetwork.player.customProperties[PhotonPlayerProperty.RCteam]) == 2)
                            {
                                str2 = "<color=#FF00FF>" + str2 + "</color>";
                            }
                        }
                    }
                    inputLine = " " + inputLine;
                    if (propHandler.XeresPropeties.ContainsKey(XeresProperty.chatColor))
                    {
                        inputLine = "<color=#" + propHandler.XeresPropeties[XeresProperty.chatColor] + ">" + inputLine + "</color>";
                    }
                    if (RCextensions.returnBoolFromObject(propHandler.XeresPropeties[XeresProperty.boldChat]))
                    {
                        inputLine = "<b>" + inputLine + "</b>";
                    }
                    if (RCextensions.returnBoolFromObject(propHandler.XeresPropeties[XeresProperty.italicChat]))
                    {
                        inputLine = "<i>" + inputLine + "</i>";
                    }
                    //inputLine = "<b> " + Xeres.Tools.ChatExtensions.colorFadeChat(new UnityEngine.Color((float)161 / 256, (float)43 / 256, (float)27 / 256), new UnityEngine.Color((float)62 / 256, (float)86 / 256, (float)201 / 256), inputLine) + "</b>";
                    if (inputLine.Contains("@"))
                    {
                        inputLine = Xeres.Tools.ChatExtensions.atUser(inputLine);
                    }
                    object[] parameters = new object[] { this.inputLine, str2 };
                    FengGameManagerMKII.instance.photonView.RPC("Chat", PhotonTargets.All, parameters);
                }
                else
                {
                    GameObject.Find("XeresManager").GetComponent<Xeres.CommandExtensions.CommandHandler>().handleCommand(inputLine);
                }
                this.inputLine = string.Empty;
                GUI.FocusControl(string.Empty);
                return;
            }
            this.inputLine = "\t";
            GUI.FocusControl("ChatInput");
        }
        Label_219C:
        ShowFPS();
        GUI.SetNextControlName(string.Empty);
        GUILayout.BeginArea(GuiRect);
        scrollPosition = GUILayout.BeginScrollView(scrollPosition);
        GUILayout.FlexibleSpace();
        foreach (string text in messages)
        {
            GUILayout.Label(text);
        }
        GUILayout.EndScrollView();
        GUILayout.EndArea();

        GUILayout.BeginArea(GuiRect2);
        GUILayout.BeginHorizontal(new GUILayoutOption[0]);
        GUI.SetNextControlName("ChatInput");
        this.inputLine = GUILayout.TextField(this.inputLine, new GUILayoutOption[0]);
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }

    public void setPosition()
    {
        if (this.AlignBottom)
        {
            GuiRect = new Rect(0f, Screen.height - 300f, 325f, 250f);
            GuiRect2 = new Rect(30f, Screen.height - 300 + 275, 300f, 25f);
            scrollPosition.y = int.MaxValue;
        }
    }

    public void Start()
    {
        this.setPosition();
    }
}

