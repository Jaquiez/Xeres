//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

public class BTN_Server_JPN : MonoBehaviour
{
    private void OnClick()
    {
        PhotonNetwork.Disconnect();
        PhotonNetwork.ConnectToMaster("172.107.193.233", 0x13bf, FengGameManagerMKII.applicationId, UIMainReferences.version);
        FengGameManagerMKII.OnPrivateServer = false;
    }
}

