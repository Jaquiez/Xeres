//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

public class BTN_SAVE_CC : MonoBehaviour
{
    public GameObject manager;

    private void OnClick()
    {
        this.manager.GetComponent<CustomCharacterManager>().SaveData();
    }
}

