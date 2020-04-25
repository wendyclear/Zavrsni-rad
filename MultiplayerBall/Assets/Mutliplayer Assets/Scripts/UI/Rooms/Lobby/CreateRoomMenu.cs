﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomName; // PAZITI DA NIKAD NIJE EMPTY
    //ExitGames.Client.Photon.Hashtable CustomeValue;

    private RoomsCanvases _roomCanvases;
    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomCanvases = canvases;
    }

    public void OnClick_CreateRoom()
    {
        
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }
        //create room
        //join or create room
        RoomOptions options = new RoomOptions();
        options.BroadcastPropsChangeToAll = true;
        options.MaxPlayers = 3;
        options.PlayerTtl = 1;
        options.EmptyRoomTtl = 1; 
        PhotonNetwork.JoinOrCreateRoom(_roomName.text, options, TypedLobby.Default);


    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created room successfully");
        //aaaaaaaaaaaaaaa
       /* if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            CustomeValue = new ExitGames.Client.Photon.Hashtable();
            CustomeValue.Add("StartTime", PhotonNetwork.Time);
            PhotonNetwork.CurrentRoom.SetCustomProperties(CustomeValue);
        }
        //aaaaaaaaaaaaaaaa*/
        _roomCanvases.CurrentRoomCanvas.Show();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room creation failed: " + message);
    }
}
