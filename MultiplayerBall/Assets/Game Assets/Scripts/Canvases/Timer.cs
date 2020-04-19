using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private int _currentTime;
    [SerializeField]
    private float _timer;
    [SerializeField]
    private Text _text;

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
        ChangeTime();
    }


    private void CountSeconds()
    {
        _timer += Time.deltaTime;
        _currentTime = Convert.ToInt32(_timer % 60) + 60 * Mathf.FloorToInt(_timer / 60);
    }

    private void ChangeTime()
    {
        if (_text.text != _currentTime.ToString())
        {
            _text.text = _currentTime.ToString();
        }
    }

    private void FirstInitialize()
    {
        _currentTime = 0;
        _timer = 0;
        _text.text = "";
    }

    public int GetTime()
    {
        return _currentTime;
    }
}
