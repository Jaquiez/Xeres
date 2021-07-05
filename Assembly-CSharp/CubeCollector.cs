//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

public class CubeCollector : MonoBehaviour
{
    public int type;

    private void Start()
    {
    }

    private void Update()
    {
        if ((GameObject.FindGameObjectWithTag("Player") != null) && (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, base.transform.position) < 8f))
        {
            UnityEngine.Object.Destroy(base.gameObject);
        }
    }
}

