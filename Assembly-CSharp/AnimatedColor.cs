//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

[ExecuteInEditMode, RequireComponent(typeof(UIWidget))]
public class AnimatedColor : MonoBehaviour
{
    public Color color = Color.white;
    private UIWidget mWidget;

    private void Awake()
    {
        this.mWidget = base.GetComponent<UIWidget>();
    }

    private void Update()
    {
        this.mWidget.color = this.color;
    }
}

