//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

public class BTN_TO_LOGIN : MonoBehaviour
{
    public GameObject loginPanel;

    private void OnClick()
    {
        NGUITools.SetActive(base.transform.parent.gameObject, false);
        NGUITools.SetActive(this.loginPanel, true);
    }
}

