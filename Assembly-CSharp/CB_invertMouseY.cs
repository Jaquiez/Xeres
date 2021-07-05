//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

public class CB_invertMouseY : MonoBehaviour
{
    private bool init;

    private void OnActivate(bool result)
    {
        if (!this.init)
        {
            this.init = true;
            if (PlayerPrefs.HasKey("invertMouseY"))
            {
                base.gameObject.GetComponent<UICheckbox>().isChecked = PlayerPrefs.GetInt("invertMouseY") == -1;
            }
            else
            {
                PlayerPrefs.SetInt("invertMouseY", 1);
            }
        }
        else
        {
            PlayerPrefs.SetInt("invertMouseY", !result ? 1 : -1);
        }
        IN_GAME_MAIN_CAMERA.invertY = PlayerPrefs.GetInt("invertMouseY");
    }
}

