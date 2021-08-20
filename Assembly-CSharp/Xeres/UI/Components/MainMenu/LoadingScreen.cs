using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Xeres.UI.Components.MainMenu
{
    public class LoadingScreen : MonoBehaviour
    {
        List<Texture2D> loadingScreens = new List<Texture2D>();
        float timer;
        int num;
        float lastTime = 0;
        int countdown = 50;
        bool isLoaded;
        void Update()
        {
            timer += Time.deltaTime;
            if(isLoaded)
            {
                countdown--;
            }
        }
        public void Start()
        {
            Console.WriteLine("Started");
            foreach(DictionaryEntry thing in XeresAssetHandler.XeresTextures)
            {
                if(thing.Key.ToString().Contains("loading"))
                {
                    loadingScreens.Add(thing.Value as Texture2D);
                }
            }
            timer = 0;
            num = -1;
            countdown = 50;
            isLoaded = false;
        }
        public void OnGUI()
        {
            if ((num==-1 || timer-lastTime>5) && !isLoaded)
            {
                num = Convert.ToInt32(UnityEngine.Random.RandomRange(0, loadingScreens.Count));
                lastTime = timer;
            }       
            
            if ((Application.isLoadingLevel || !FengGameManagerMKII.customLevelLoaded || !FengGameManagerMKII.logicLoaded) && !isLoaded)
            {
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), loadingScreens[num] as Texture2D);
            }          
            else
            {
                GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<LoadingScreen>());
                GameObject.Find("XeresUIManager").AddComponent<InGame.Console>();
                GameObject.Destroy(GameObject.Find("XeresUIManager").GetComponent<InGame.Console>());
                //Attempted fading loading screen upon completion, not working for some reason
                /*
                isLoaded = true;
                if(countdown>=0)
                {
                    Texture2D newText = loadingScreens[num] as Texture2D;
                    Color[] pix = newText.GetPixels();
                    float val = countdown / 100f;
                    for (int k = 0; k < pix.Length; k++)
                    {
                        pix[k].a = val;
                    }
                    newText.SetPixels(pix);
                    newText.Apply();
                    GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), newText);
                }
                else
                {
                    GameObject.Destroy(GameObject.Find("XeresUIManager"));
                }*/
            }
        }
    }
}
