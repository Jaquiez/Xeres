using UnityEngine;
using System;
namespace Xeres.UI.Components.MainMenu
{
    public class MultiplayerPanel : MonoBehaviour
    {
        Rect GUIRect = new Rect(Screen.width-Screen.width*.906f, Screen.height-Screen.height*7/9f, Screen.width* .8125f, Screen.height * 5 / 9f);
        Rect GUIRect2 = new Rect(Screen.width - Screen.width * .906f, Screen.height-Screen.height*.8701f, Screen.width * .8125f, Screen.height*.09259f);
        Rect GUIRect3 = new Rect(Screen.width - Screen.width * .906f, Screen.height*7/9f, Screen.width * .8125f, Screen.height*.05f);
        Rect GUIRect4 = new Rect(Screen.width - Screen.width * .906f-5f, Screen.height - Screen.height * .8701f-5f, Screen.width * .8125f+10f, Screen.height * .05f+Screen.height * 5 / 9f+ Screen.height * .09259f+10f);
        Vector2 scrollPos = Vector2.zero;//600 +240
        ExitGames.Client.Photon.Hashtable settings;
        string[] regions= { "US", "EU", "AS", "SA" };
        int _region;
        private Setting network;
        private static int port;
        public void Start()
        {
            Setting network = new Xeres.Options.Settings.NetworkSetting();
            if (network.getTempUserData("Network")["ConnectionProtocol"] as string == "UDP")
                port = 5055;
            else
                port = 4530;
            Console.WriteLine($"Connection Protocol {network.getTempUserData("Network")["ConnectionProtocol"] as string} Port {port}");
            if (!PhotonNetwork.connected)
            {

                switch (network.getTempUserData("Network")["DefaultRegion"] as string)
                {
                    case "US":
                        PhotonNetwork.Disconnect();
                        PhotonNetwork.ConnectToMaster("142.44.242.29", port, FengGameManagerMKII.applicationId, UIMainReferences.version);
                        _region = 0;
                        break;
                    case "EU":
                        PhotonNetwork.Disconnect();
                        PhotonNetwork.ConnectToMaster("135.125.239.180", port, FengGameManagerMKII.applicationId, UIMainReferences.version);
                        _region = 1;
                        break;
                    case "AS":
                        PhotonNetwork.Disconnect();
                        PhotonNetwork.ConnectToMaster("51.79.164.137", port, FengGameManagerMKII.applicationId, UIMainReferences.version);
                        _region = 2;
                        break;
                    case "SA":
                        PhotonNetwork.Disconnect();
                        PhotonNetwork.ConnectToMaster("172.107.193.233", port, FengGameManagerMKII.applicationId, UIMainReferences.version);
                        _region = 3;
                        break;
                    default:
                        break;
                }
            }
            settings = new ExitGames.Client.Photon.Hashtable();
            settings.Add("filter", "");
            settings.Add("showPWD", true);
            settings.Add("showFullRooms", true);
        }
        public void OnGUI()
        {
            GUIStyle button = new GUIStyle("button");
            button.fontSize = Screen.width / 70;
            button.alignment = TextAnchor.MiddleCenter;
            GUIStyle label = new GUIStyle("label");
            label.fontSize = Screen.width / 100;
            GUIStyle toggle = new GUIStyle("toggle");
            toggle.fontSize = Screen.width / 120;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), XeresAssetHandler.XeresTextures["Background"] as Texture2D);

            GUI.Box(GUIRect4,"");
            GUILayout.BeginArea(GUIRect2);
            GUILayout.Space(0.0225f*Screen.height);
            GUILayout.BeginHorizontal(new GUILayoutOption[] { GUILayout.MaxWidth(Screen.width * .8125f) });
            GUILayout.Space(0.01f * Screen.height);
            GUILayout.Label("Filter:",label,new GUILayoutOption[] { GUILayout.Width(.03f*Screen.width)});
            settings["filter"] = GUILayout.TextField((string)settings["filter"],new GUILayoutOption[] { GUILayout.ExpandWidth(true),GUILayout.MinWidth(50f),GUILayout.Width(Screen.width*.1f),GUILayout.Height(Screen.height*1/40) });
            //        public static bool Toggle(bool value, string text, GUIStyle style, params GUILayoutOption[] options);
            settings["showPWD"] = GUILayout.Toggle(value:(bool)settings["showPWD"], text:"Show PWD Rooms", toggle, new GUILayoutOption[] { GUILayout.MaxWidth(175f) });
            settings["showFullRooms"] = GUILayout.Toggle(value:(bool)settings["showFullRooms"], text: "Show Full Rooms",toggle,new GUILayoutOption[] { GUILayout.MaxWidth(175f) });
            GUILayout.Label("Connected to <b>" + regions[_region] + "</b> | Players: " + PhotonNetwork.countOfPlayers,label) ;
            foreach(string region in regions)
            {
                if (GUILayout.Button(region,button,new GUILayoutOption[] { GUILayout.Width(.08f * Screen.width),GUILayout.Height(.05f * Screen.height) }))
                {
                    switch(region)
                    {
                        case "US":
                            PhotonNetwork.Disconnect();
                            PhotonNetwork.ConnectToMaster("142.44.242.29", port, FengGameManagerMKII.applicationId, UIMainReferences.version);
                            _region = 0;
                            break;
                        case "EU":
                            PhotonNetwork.Disconnect();
                            PhotonNetwork.ConnectToMaster("135.125.239.180", port, FengGameManagerMKII.applicationId, UIMainReferences.version);
                            _region = 1;
                            break;
                        case "AS":
                            PhotonNetwork.Disconnect();
                            PhotonNetwork.ConnectToMaster("51.79.164.137", port, FengGameManagerMKII.applicationId, UIMainReferences.version);
                            _region = 2;
                            break;
                        case "SA":
                            PhotonNetwork.Disconnect();
                            PhotonNetwork.ConnectToMaster("172.107.193.233", port, FengGameManagerMKII.applicationId, UIMainReferences.version);
                            _region = 3;
                            break;
                        default:
                            break;
                    }
                }
            }
            GUILayout.EndHorizontal();
            GUILayout.EndArea();

            GUILayout.BeginArea(GUIRect);
            scrollPos = GUILayout.BeginScrollView(scrollPos);

            foreach(RoomInfo room in PhotonNetwork.GetRoomList())
            {
                if (room.name.Contains("==") && !(bool)settings["showPWD"])
                    continue;
                if (room.maxPlayers == room.playerCount && !(bool)settings["showFullRooms"])
                    continue;
                string[] name = room.name.Split('`');
                string displayName = "" + name[0].hexColor() + " | " + name[1] + " | <color=#ff4757> Difficulty: " + name[2].ToUpper() + "</color> | <color=#ff7f50> Players: " + room.playerCount + "/" + room.maxPlayers + "</color>";
                displayName += room.name.Contains("==") ? " | <color=#ff0000> PWD </color>" : "";
                if(room.name.ToLower().Contains(settings["filter"].ToString().ToLower()))
                { 
                    if (GUILayout.Button(displayName, button, new GUILayoutOption[] { GUILayout.ExpandHeight(true),GUILayout.MinHeight(50) }))
                    {
                        PhotonNetwork.JoinRoom(room.name);
                    }
                }
            }
            GUILayout.EndScrollView();
            GUILayout.EndArea();

            GUILayout.BeginArea(GUIRect3);
            GUILayout.Space(Screen.height * .015f);
            GUILayout.BeginHorizontal();
            
            if(GUILayout.Button("Create Game",button))
            {
                GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<MultiplayerPanel>());
                GameObject.Find("XeresUIManager").AddComponent<CreateMultiGamePanel>();
            }
            if(GUILayout.Button("Offline-Online", button))
            {
                //GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<MultiplayerPanel>());
                //PhotonNetwork.offlineMode = true;
                //GameObject.Find("XeresUIManager").AddComponent<CreateMultiGamePanel>();
            }
            if(GUILayout.Button("Back",button))
            {
                PhotonNetwork.Disconnect();
                GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<MultiplayerPanel>());
                GameObject.Find("XeresUIManager").AddComponent<Xeres.UI.Components.MainMenu.PreferenceSetter>();
                GameObject.Find("XeresUIManager").AddComponent<Xeres.UI.Components.MainMenu.MainMenuButtons>();
                GameObject.Find("XeresUIManager").AddComponent<Xeres.UI.Components.MainMenu.Title>();
            }
            GUILayout.EndHorizontal();
            GUILayout.EndArea();

        }
    }
}
