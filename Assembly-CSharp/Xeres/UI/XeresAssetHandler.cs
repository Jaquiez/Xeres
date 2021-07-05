using UnityEngine;
using System.IO;
using System;
using System.Collections;
namespace Xeres.UI
{
    public class XeresAssetHandler
    {
		public static AssetBundle XeresAssets;
		public static AssetBundle maps;
		public static ExitGames.Client.Photon.Hashtable XeresTextures = new ExitGames.Client.Photon.Hashtable();
		//public Components.MainMenu mainMenu;
		public static void Init()
		{			
			byte[] yomama = File.ReadAllBytes(Path.Combine(Application.dataPath, "Xeres.unity3d"));
			XeresAssets = AssetBundle.CreateFromMemoryImmediate(yomama);
			string[] files = Directory.GetFiles(Application.dataPath + @"/Resources/Xeres/");
			foreach (string name in files)
            {
				Texture2D tex = new Texture2D(1920, 1080);
				tex.LoadImage(File.ReadAllBytes(name));
				int pos = name.LastIndexOf(".");
				string fileName = "";
				if (pos > 0)
					fileName = name.Substring(name.LastIndexOf("/")+1, pos -(1+name.LastIndexOf("/")));
				XeresTextures.Add(fileName,tex);
			
			}
			
			Console.WriteLine(XeresTextures.ToStringFull());
		}

	}
}
