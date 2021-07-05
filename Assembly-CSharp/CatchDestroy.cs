//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

public class CatchDestroy : MonoBehaviour
{
    public GameObject target;

    private void OnDestroy()
    {
        if (this.target != null)
        {
            UnityEngine.Object.Destroy(this.target);
        }
    }
}

