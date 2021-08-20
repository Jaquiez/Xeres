using UnityEngine;
using System;
using System.Collections;
namespace Xeres.UI
{
    public class UITools
    {
	private static int virtualWidth = 1920;
	private static int virtualHeight = 1080;
        //Completely useless now cuz it makes everything look lower resolution/quality
        public static void scaleUI()
        {
            Vector3 scale = new Vector3();
            scale.x = (float)Screen.width / virtualWidth;
            scale.y = (float)Screen.height / virtualHeight;
            scale.z = 1f;
            GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
        }

        public static DictionaryEntry createDropdownMenu(string[] elements, bool isOpen, string firstElement)
        {
            if(GUILayout.Button(firstElement))
            {
                if (!isOpen)
                    isOpen = true;
                else
                    isOpen = false;
            }
            if(isOpen)
            {
                foreach (string element in elements)
                {
                    if (firstElement.Equals(element))
                        continue;
                    if (GUILayout.Button(element))
                    {
                        firstElement = element;
                        isOpen = false;
                    }
                }
            }
            return new DictionaryEntry(firstElement,isOpen);
        }
        //Unityy GUI has an implimentation for this through GUI.SelectionGrid but I will still use this
        public static DictionaryEntry createDropdownMenu(string[] elements, bool isOpen, string firstElement, GUIStyle style)
        {
            if (GUILayout.Button(firstElement,style))
            {
                if (!isOpen)
                    isOpen = true;
                else
                    isOpen = false;
            }
            if (isOpen)
            {
                foreach (string element in elements)
                {
                    if (firstElement.Equals(element))
                        continue;
                    if (GUILayout.Button(element,style))
                    {
                        firstElement = element;
                        isOpen = false;
                    }
                }
            }
            return new DictionaryEntry(firstElement, isOpen);
        }
        public static DictionaryEntry createDropdownMenu(string[] elements, bool isOpen, string firstElement, GUIStyle style, GUILayoutOption[] settings)
        {
            if (GUILayout.Button(firstElement, style,settings))
            {
                if (!isOpen)
                    isOpen = true;
                else
                    isOpen = false;
            }
            if (isOpen)
            {
                foreach (string element in elements)
                {
                    if (firstElement.Equals(element))
                        continue;
                    if (GUILayout.Button(element, style,settings))
                    {
                        firstElement = element;
                        isOpen = false;
                    }
                }
            }
            return new DictionaryEntry(firstElement, isOpen);
        }
    }
}

