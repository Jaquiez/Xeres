//Fixed With [DOGE]DEN aottg Sources fixerBTN_Server
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

public class BTN_ServerUS : MonoBehaviour
{
    private void OnClick()
    {
        PhotonNetwork.Disconnect();
        PhotonNetwork.ConnectToMaster("142.44.242.29", 5055, FengGameManagerMKII.applicationId, UIMainReferences.version);
        FengGameManagerMKII.OnPrivateServer = false;
    }
}

