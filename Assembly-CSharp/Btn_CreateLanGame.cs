//Fixed With [DOGE]DEN aottg Sources fixer
//Doge Guardians FTW
//DEN is OP as fuck.
//Farewell Cowboy

using System;
using UnityEngine;

public class Btn_CreateLanGame : MonoBehaviour
{
    private void OnClick()
    {
        PhotonNetwork.Disconnect();
        MonoBehaviour.print("IP:" + Network.player.ipAddress + Network.player.externalIP);
        PhotonNetwork.ConnectToMaster(Network.player.ipAddress, 0x13bf, FengGameManagerMKII.applicationId, UIMainReferences.version);
    }

    private void Start()
    {
        UnityEngine.Object.Destroy(base.gameObject);
    }
}

