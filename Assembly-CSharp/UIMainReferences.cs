//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class UIMainReferences : MonoBehaviour
{
    public static string fengVersion;
    private static bool isGAMEFirstLaunch = true;
    public GameObject panelCredits;
    public GameObject PanelDisconnect;
    public GameObject panelMain;
    public GameObject PanelMultiJoinPrivate;
    public GameObject PanelMultiPWD;
    public GameObject panelMultiROOM;
    public GameObject panelMultiSet;
    public GameObject panelMultiStart;
    public GameObject PanelMultiWait;
    public GameObject panelOption;
    public GameObject panelSingleSet;
    public GameObject PanelSnapShot;
    public static string version = "01042015";
    //Xeres stuff
    public static GameObject XeresManager;
    public static GameObject XeresUIManager;
    public IEnumerator request(string versionShow, string versionForm)
    {
        string url = Application.dataPath + "/RCAssets.unity3d";
        if (!Application.isWebPlayer)
        {
            url = "File://" + url;
        }
        while (!Caching.ready)
        {
            yield return null;
        }
        int version = 1;
        using (WWW iteratorVariable2 = WWW.LoadFromCacheOrDownload(url, version))
        {
            yield return iteratorVariable2;
            if (iteratorVariable2.error != null)
            {
                throw new Exception("WWW download had an error:" + iteratorVariable2.error);
            }
            FengGameManagerMKII.RCassets = iteratorVariable2.assetBundle;
            FengGameManagerMKII.isAssetLoaded = true;
            FengGameManagerMKII.instance.setBackground();
        }
    }

    private void Start()
    {


        string versionShow = "8/12/2015";
        string versionForm = "08122015";
        fengVersion = "01042015";
        NGUITools.SetActive(this.panelMain, true);
        if (!GameObject.Find("XeresManager"))
        {
            GameObject updater = new GameObject("updater");
            updater.AddComponent<Xeres.AutoUpdater.UpdateManager>();
            Xeres.UI.XeresAssetHandler.Init();
            XeresManager = new GameObject("XeresManager");
            XeresManager.AddComponent<Xeres.CommandExtensions.CommandHandler>();
            XeresManager.AddComponent<Xeres.UserPrefs.PropertyHandler>();
            XeresManager.AddComponent<Xeres.Options.SettingHandler>();
            DontDestroyOnLoad(XeresManager);
        }

        if (!GameObject.Find("XeresUIManager")  && IN_GAME_MAIN_CAMERA.gametype == GAMETYPE.STOP )
        {
            XeresUIManager = new GameObject("XeresUIManager");
            if(GameObject.Find("updater"))
            {
                XeresUIManager.AddComponent<Xeres.UI.Components.MainMenu.StartUp>();
            }
            else
            {
                GameObject.Find("XeresUIManager").AddComponent<Xeres.UI.Components.MainMenu.PreferenceSetter>();
                GameObject.Find("XeresUIManager").AddComponent<Xeres.UI.Components.MainMenu.MainMenuButtons>();
                GameObject.Find("XeresUIManager").AddComponent<Xeres.UI.Components.MainMenu.Title>();
            }
        }

        if ((version == null) || version.StartsWith("error"))
        {
            GameObject.Find("VERSION").GetComponent<UILabel>().text = "Verification failed. Please clear your cache or try another browser";
        }
        else if (version.StartsWith("outdated"))
        {
            GameObject.Find("VERSION").GetComponent<UILabel>().text = "Mod is outdated. Please clear your cache or try another browser.";
        }
        else
        {
            GameObject.Find("VERSION").GetComponent<UILabel>().text = "Client verified. Last updated " + versionShow + ".";
        }
        if (isGAMEFirstLaunch)
        {
            version = fengVersion;
            isGAMEFirstLaunch = false;
            GameObject target = (GameObject) UnityEngine.Object.Instantiate(Resources.Load("InputManagerController"));
            target.name = "InputManagerController";
            UnityEngine.Object.DontDestroyOnLoad(target);
            GameObject.Find("VERSION").GetComponent<UILabel>().text = "Client verified. Last updated " + versionShow + ".";
            FengGameManagerMKII.s = "verified343,hair,character_eye,glass,character_face,character_head,character_hand,character_body,character_arm,character_leg,character_chest,character_cape,character_brand,character_3dmg,r,character_blade_l,character_3dmg_gas_r,character_blade_r,3dmg_smoke,HORSE,hair,body_001,Cube,Plane_031,mikasa_asset,character_cap_,character_gun".Split(new char[] { ',' });
            base.StartCoroutine(this.request(versionShow, versionForm));
            FengGameManagerMKII.loginstate = 0;
        }

        /*
        NGUITools.SetActive(GameObject.Find("UIRefer").GetComponent<UIMainReferences>().panelMultiStart, false);
        NGUITools.SetActive(GameObject.Find("UIRefer").GetComponent<UIMainReferences>().panelMultiROOM, false);
        NGUITools.SetActive(GameObject.Find("UIRefer").GetComponent<UIMainReferences>().panelCredits, false);
        NGUITools.SetActive(GameObject.Find("UIRefer").GetComponent<UIMainReferences>().panelMultiSet, false);
        NGUITools.SetActive(GameObject.Find("UIRefer").GetComponent<UIMainReferences>().panelMain, false);*/
    }

}

