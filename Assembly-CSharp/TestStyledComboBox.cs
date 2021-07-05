//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

public class TestStyledComboBox : MonoBehaviour
{
    public StyledComboBox comboBox;

    private void Start()
    {
        object[] list = new object[] { "English", "简体中文", "繁體中文", "繁體中文", "繁體中文", "繁體中文", "繁體中文", "繁體中文", "繁體中文", "繁體中文", "繁體中文" };
        this.comboBox.AddItems(list);
    }
}

