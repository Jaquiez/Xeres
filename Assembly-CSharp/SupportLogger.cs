//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

public class SupportLogger : MonoBehaviour
{
    public bool LogTrafficStats = true;

    public void Start()
    {
        if (GameObject.Find("PunSupportLogger") == null)
        {
            GameObject target = new GameObject("PunSupportLogger");
            UnityEngine.Object.DontDestroyOnLoad(target);
            target.AddComponent<SupportLogging>().LogTrafficStats = this.LogTrafficStats;
        }
    }
}

