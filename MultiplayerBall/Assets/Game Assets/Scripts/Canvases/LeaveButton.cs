using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveButton : MonoBehaviour
{
    public void OnClick_LeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
        PhotonNetwork.LoadLevel(1); // ROOM INDEX!!!!
    }

}
