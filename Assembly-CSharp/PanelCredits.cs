//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

public class PanelCredits : MonoBehaviour
{
    public GameObject label_back;
    public GameObject label_title;
    private int lang = -1;

    private void showTxt()
    {
        if (this.lang != Language.type)
        {
            this.lang = Language.type;
            this.label_title.GetComponent<UILabel>().text = Language.btn_credits[Language.type];
            this.label_back.GetComponent<UILabel>().text = Language.btn_back[Language.type];
        }
    }

    private void Update()
    {
        this.showTxt();
    }
}

