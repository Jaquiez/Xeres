using UnityEngine;
public static class XeresStyle
{
    public static GUISkin skin;
    public static void setGUIStyle()
    {
        Texture2D colorNormal = new Texture2D(1, 1, TextureFormat.ARGB32, false);
        colorNormal.SetPixel(0, 0, new Color(164 / 256f, 176 / 256f, 190 / 256f, .25f));
        colorNormal.Apply();
        Texture2D colorHovor = new Texture2D(1, 1, TextureFormat.ARGB32, false);
        colorHovor.SetPixel(0, 0, new Color(87 / 256f, 96 / 256f, 111 / 256f, .25f));
        colorHovor.Apply();
        Texture2D colorActive = new Texture2D(1, 1, TextureFormat.ARGB32, false);
        colorActive.SetPixel(0, 0, new Color(116 / 256f, 125 / 256f, 140 / 256f, .25f));
        colorActive.Apply();
        Texture2D colorBackground = new Texture2D(1, 1, TextureFormat.ARGB32, false);
        colorBackground.SetPixel(0, 0, new Color(2f / 256, 35 / 256, 42 / 256, .5f));
        colorBackground.Apply();

        GUI.skin.box.normal.background = colorBackground;
        GUIStyle butt = new GUIStyle("button");
        butt.hover.background = colorHovor;
        butt.normal.background = colorNormal;
        butt.active.background = colorActive;
        GUI.skin.button = butt;

        GUI.skin.verticalScrollbar.normal.background = colorHovor;
        GUI.skin.verticalScrollbarThumb.normal.background = colorNormal;

        GUI.skin.horizontalScrollbar.normal.background = colorHovor;
        GUI.skin.horizontalScrollbarThumb.normal.background = colorNormal;

        GUI.skin.scrollView.normal.background = colorBackground;

        GUI.skin.textField.normal.background = colorNormal;
        GUI.skin.textField.focused.background = colorNormal;
        GUI.skin.textField.active.background = colorActive;
        GUI.skin.textField.hover.background = colorHovor;

        //Font font = Xeres.UI.XeresAssetHandler.XeresAssets.Load("consolas") as Font;
        //GUI.skin.font = font;

        GUI.skin.name = "yo mama";

    }   
    public static GUISkin GetGUISkin()
    {
        setGUIStyle();
        return GUI.skin;
    }
}

