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
    [SerializeField]
    private Text _buffText;
    private int _buffTimeReduce;
    private int _buffs;

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
        CheckBuff();
    }


    private void CountSeconds()
    {
        _timer += Time.deltaTime;
        _currentTime = Convert.ToInt32(_timer % 60) + 60 * Mathf.FloorToInt(_timer / 60) - _buffs * _buffTimeReduce;
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
        _buffs = 0;
        _buffTimeReduce = 10;
    }

    public int GetTime()
    {
        return _currentTime;
    }

    public void GetBuff()
    {
        _buffText.gameObject.SetActive(true);
        _buffText.canvasRenderer.SetAlpha(1);
        _buffText.CrossFadeAlpha(0, 3, false);
        _buffs += 1;

    }

    private void CheckBuff()
    {
        if (_buffText.gameObject.activeSelf)
        {
            if (_buffText.canvasRenderer.GetAlpha() == 0)
            {
                _buffText.gameObject.SetActive(false);
            }
        }
    }
}
