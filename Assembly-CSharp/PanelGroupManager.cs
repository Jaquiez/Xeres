//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

public class PanelGroupManager
{
    public GameObject[] panelGroup;

    public void ActivePanel(int index)
    {
        foreach (GameObject obj2 in this.panelGroup)
        {
            obj2.SetActive(false);
        }
        this.panelGroup[index].SetActive(true);
    }
}

