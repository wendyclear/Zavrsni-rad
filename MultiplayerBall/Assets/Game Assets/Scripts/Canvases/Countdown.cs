using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField]
    private GameObject _invisibleWalls;
    [SerializeField]
    private int _countDownTime;
    [SerializeField]
    private int _currentTime;
    [SerializeField]
    private float _timer;
    [SerializeField]
    private Text _text;
    [SerializeField]
    private GameObject _canvasManager;

    // Start is called before the first frame update
    void Start()
    {
        FirstInitialize();
    }
    private void Awake()
    {
        FirstInitialize();
    }

    // Update is called once per frame
    void Update()
    {

        CountSeconds();
        if (_currentTime > 0) ChangeTime();
        else if (_currentTime > -1) _text.text = "START";
        else StartGame();
    }


    private void CountSeconds()
    {
        _timer += Time.deltaTime;
        _currentTime = _countDownTime - Convert.ToInt32(_timer % 60);
    }

    private void ChangeTime()
    {
        if (_text.text != _currentTime.ToString())
        {
            _text.text = _currentTime.ToString();
        }
    }

    private void StartGame()
    {
        _invisibleWalls.SetActive(false);
        _canvasManager.GetComponent<GameCanvasManager>().StartCounter();

    }

    private void FirstInitialize()
    {
        _countDownTime = 5;
        _currentTime = 0;
        _timer = 0;
        _text.text = "";
    }
}
