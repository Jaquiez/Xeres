//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

public class RCRegionLabel : MonoBehaviour
{
    public GameObject myLabel;

    private void Update()
    {
        if ((this.myLabel != null) && this.myLabel.GetComponent<UILabel>().isVisible)
        {
            this.myLabel.transform.LookAt(((Vector3) (2f * this.myLabel.transform.position)) - Camera.main.transform.position);
        }
    }
}

