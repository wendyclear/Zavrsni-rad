using Photon.Pun;
using Photon.Realtime;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connect : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        //print("Connecting to server...");
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            //PhotonNetwork.SendRate = 20; // 20 on default per second
            //PhotonNetwork.SerializationRate = 5; // 10 on default per second (the bigger the value , the bigger lag) 
            //AuthenticationValues authValues = new AuthenticationValues("0"); -> treba biti unique
            //PhotonNetwork.AuthValues = authValues;
            PhotonNetwork.GameVersion = "0.0.1"; // da se igra ne brejka ako se razlicite verzije spajaju, tu nece bit toga
            PhotonNetwork.NickName = MasterManager.GameSettings.Nickname;
            PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.ConnectToRegion("0");
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnConnectedToMaster()
    {
        //print("Connected to server.");
       // print(PhotonNetwork.LocalPlayer.NickName);
        if (!PhotonNetwork.InLobby)
        {
            //print("Connected to lobby.");
            PhotonNetwork.JoinLobby(); // lobby type = default
        }
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        //base.OnDisconnected(cause);
        //print("Disconnected from server because :"+cause.ToString());
    }
}
