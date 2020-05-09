using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvasManager : MonoBehaviourPun
{
    [SerializeField]
    private GameObject _gameOverCanvas; 
    [SerializeField]
    private GameObject _leaveCanvas;
    [SerializeField]
    private GameObject _gameFinishedCanvas;
    [SerializeField]
    private GameObject _countdownCanvas;
    [SerializeField]
    private GameObject _timerCanvas;
    // Start is called before the first frame update

    public void GameOver()
    {
        _leaveCanvas.SetActive(false);
        _timerCanvas.SetActive(false);
        _gameOverCanvas.GetComponent<Result>().SetResult(_timerCanvas.GetComponent<Timer>().GetTime());
        _gameOverCanvas.SetActive(true);
    }
    public void GameFinished()
    {
        _timerCanvas.SetActive(false);
        _leaveCanvas.SetActive(false);
        _gameFinishedCanvas.GetComponent<Result>().SetResult(_timerCanvas.GetComponent<Timer>().GetTime());
        _gameFinishedCanvas.SetActive(true);
    }

    public void StartCounter()
    {
        _countdownCanvas.SetActive(false);
        _timerCanvas.SetActive(true);
    }

    public void GetBuff()
    {
        _timerCanvas.GetComponent<Timer>().GetBuff();
    }
}
