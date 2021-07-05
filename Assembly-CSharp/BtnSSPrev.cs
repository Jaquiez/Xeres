//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

public class BtnSSPrev : MonoBehaviour
{
    private void OnClick()
    {
        if (base.gameObject.transform.parent.gameObject.GetComponent<CharacterCreationComponent>() != null)
        {
            base.gameObject.transform.parent.gameObject.GetComponent<CharacterCreationComponent>().prevOption();
        }
        else
        {
            base.gameObject.transform.parent.gameObject.GetComponent<CharacterStatComponent>().prevOption();
        }
    }
}

