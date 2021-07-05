//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

public class BTN_SetDefault : MonoBehaviour
{
    private void OnClick()
    {
        GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().setToDefault();
        GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().showKeyMap();
    }
}

