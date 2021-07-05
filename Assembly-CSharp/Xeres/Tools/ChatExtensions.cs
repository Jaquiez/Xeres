using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Xeres.Tools
{
    public class ChatExtensions
    {
        //Server limits messages to 1000 chars so color fade will be useless
        public static String colorFadeChat(UnityEngine.Color start, UnityEngine.Color end, String chat)
        {
            if (chat.Length <= 1)
            {
                return "<color=#" + toHTMLColor(start) + ">" + chat + "</color>";
            }
            char[] words = chat.ToCharArray();
            chat = "";
            for (int k = 0; k < words.Length; k++)
            {
                double multiplier = k / (double)(words.Length - 1);
                Color newTing = new Color((float)(start.r + (end.r - start.r) * multiplier), (float)(start.g + (end.g - start.g) * multiplier), (float)(start.b + (end.b - start.b) * multiplier));
                chat += "<color=#" + toHTMLColor(newTing) + ">" + words[k] + "</color>";
            }
            return chat;
        }

        public static String toHTMLColor(Color color)
        {
            string firstPart = Convert.ToString((int)(color.r * 255f), 16);
            string secondPart = Convert.ToString((int)(color.g * 255f), 16);
            string thirdPart = Convert.ToString((int)(color.b * 255f), 16);
            if (color.r * 255f < 16)
            {
                firstPart = "0" + Convert.ToString((int)(color.r * 255f), 16);
            }
            if (color.g * 255f < 16)
            {
                secondPart = "0" + Convert.ToString((int)(color.g * 255f), 16);
            }
            if (color.b * 255f < 16)
            {
                thirdPart = "0" + Convert.ToString((int)(color.b * 255f), 16);
            }
            return firstPart + secondPart + thirdPart;
        }

        public static string atUser(string inputLine)
        {
            inputLine += " ";
            List<char> letters = inputLine.ToCharArray().ToList<char>();
            int length = inputLine.ToCharArray().Length;
            for (int k = 0; k < length-1; k++)
            {
                if (letters[k].Equals('@'))
                {
                    int i = k+1;
                    string ID = "";
                    if(!Char.IsNumber((letters[i])))
                        continue;
                    while (Char.IsNumber(letters[i]))
                    {                        
                        ID += letters[i];
                        letters.RemoveAt(i);                    
                    }
                    PhotonPlayer player = PhotonPlayer.Find(Convert.ToInt32(ID));          
                    if(player!=null)
                    {
                        foreach (char car in RCextensions.returnStringFromObject(player.customProperties[PhotonPlayerProperty.name]).hexColor().ToCharArray())
                        {
                            k++;
                            letters.Insert(k, car);
                        }
                    }
                    length = letters.ToArray().Length;
                }
            }
            string str = new string(letters.ToArray());
            return str;
        }

    }
}
