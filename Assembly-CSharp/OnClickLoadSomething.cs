//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

public class OnClickLoadSomething : MonoBehaviour
{
    public string ResourceToLoad;
    public ResourceTypeOption ResourceTypeToLoad;

    public void OnClick()
    {
        switch (this.ResourceTypeToLoad)
        {
            case ResourceTypeOption.Scene:
                Application.LoadLevel(this.ResourceToLoad);
                break;

            case ResourceTypeOption.Web:
                Application.OpenURL(this.ResourceToLoad);
                break;
        }
    }

    public enum ResourceTypeOption : byte
    {
        Scene = 0,
        Web = 1
    }
}

