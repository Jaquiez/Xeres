//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

public class BTN_LEADERBOARD : MonoBehaviour
{
    public GameObject leaderboard;
    public GameObject mainMenu;

    private void OnClick()
    {
        NGUITools.SetActive(this.mainMenu, false);
        NGUITools.SetActive(this.leaderboard, true);
    }
}

