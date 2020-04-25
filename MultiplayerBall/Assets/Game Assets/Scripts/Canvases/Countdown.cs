using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviourPun
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    private GameObject _invisibleWalls;
    [SerializeField]
    private GameObject _canvasManager;
    [SerializeField]
    private bool _start = false;
    [SerializeField]
    private double timerIncrementValue;
    [SerializeField]
    private double startTime;
    [SerializeField] 
    private double timer = 6;
    [SerializeField]
    private int _countDownTime;
    ExitGames.Client.Photon.Hashtable CustomeValue;

    private void Awake()
    {
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
             CustomeValue = new ExitGames.Client.Photon.Hashtable();
             startTime = PhotonNetwork.Time;
             CustomeValue.Add("StartTime", startTime);
             PhotonNetwork.CurrentRoom.SetCustomProperties(CustomeValue);
            _text.text = "";
        }
    }
    void Start()
    {
            startTime = double.Parse(PhotonNetwork.CurrentRoom.CustomProperties["StartTime"].ToString());
            _text.text = "";
    }

    void Update()
    {
        if (startTime == 0)
        {
            startTime = double.Parse(PhotonNetwork.CurrentRoom.CustomProperties["StartTime"].ToString());

        }
        timerIncrementValue = timer - (int)(PhotonNetwork.Time - startTime);

        if (timerIncrementValue >= 1)
        {
            ChangeTime();
        }
        else
        {
            if (timerIncrementValue == 0)
            {
                _text.text = "START";
            }
            else
            {
                StartGame();
            }
        }


    }
    private void StartGame()
    {
        _invisibleWalls.SetActive(false);
        _canvasManager.GetComponent<GameCanvasManager>().StartCounter();

    }

    private void ChangeTime()
    {
        if (_text.text != timerIncrementValue.ToString())
        {
            _text.text = timerIncrementValue.ToString();
        }
    }
}
