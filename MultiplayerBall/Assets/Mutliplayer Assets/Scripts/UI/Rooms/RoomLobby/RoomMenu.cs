using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _playersCountText;

    private RoomsCanvases _roomsCanvases;


    public void Update()
    {
        _playersCountText.text = "Players in room : " + PhotonNetwork.CurrentRoom.PlayerCount;
    }
    public override void OnEnable()
    {
        base.OnEnable();
    }

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }

    public override void OnMasterClientSwitched(Player newMasterClient) //kad god ode master
    {
        PhotonNetwork.LeaveRoom(true);
        _roomsCanvases.CurrentRoomCanvas.Hide();

    }

    public void ClickButton_StartGame() //startgame
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel(2); // ROOM INDEX!!!!
        }
    }
}
