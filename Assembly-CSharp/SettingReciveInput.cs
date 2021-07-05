//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

public class SettingReciveInput : MonoBehaviour
{
    public int id;

    private void OnClick()
    {
        GameObject.Find("InputManagerController").GetComponent<FengCustomInputs>().startListening(this.id);
        base.transform.Find("Label").gameObject.GetComponent<UILabel>().text = "*wait for input";
    }

    private void Start()
    {
    }

    private void Update()
    {
    }
}

