using UnityEngine;
using System;

namespace Xeres.UI.Components.MainMenu
{
    public class Title : MonoBehaviour
    {
        Vector2 scrollPos = Vector2.zero;
        public void Start()
        {
        }
        public void OnGUI()
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), XeresAssetHandler.XeresTextures["Background"] as Texture2D);
            GUIStyle label = new GUIStyle("label");
            label.font = XeresAssetHandler.XeresAssets.Load("solander") as Font;
            label.fontSize =  80;
            label.alignment = TextAnchor.MiddleLeft;
            Texture2D cloud = XeresAssetHandler.XeresTextures["cloud"] as Texture2D;
            cloud.SetPixel(0, 0, new Color(0f, 0f, 0f, .1f));
            GUI.DrawTexture(new Rect(Screen.width * .5f - 200, Screen.height - Screen.height * .95f, 400, 200), cloud);
            GUI.Label(new Rect(Screen.width*.5f-150, Screen.height-Screen.height*.95f, 400, 200), "<color=#60879e> X E R E S </color>", label);
        }
    }
}
