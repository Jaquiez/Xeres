//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

public class BTN_Server_EU : MonoBehaviour
{
    private void OnClick()
    {
        PhotonNetwork.Disconnect();
        PhotonNetwork.ConnectToMaster("135.125.239.180", 5055, FengGameManagerMKII.applicationId, UIMainReferences.version);
        FengGameManagerMKII.OnPrivateServer = false;
    }
}

