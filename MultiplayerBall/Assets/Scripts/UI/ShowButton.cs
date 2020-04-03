using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowButton : MonoBehaviourPunCallbacks
{
    public GameObject StartGameButton;
    public void Awake()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            StartGameButton.SetActive(true);
        }
        else
        {
            StartGameButton.SetActive(false);
        }
    }
}
