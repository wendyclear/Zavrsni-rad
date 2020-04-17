using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvasManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverCanvas; 
    [SerializeField]
    private GameObject _leaveCanvas;
    // Start is called before the first frame update

    public void GameOver()
    {
        _leaveCanvas.SetActive(false);
        _gameOverCanvas.SetActive(true);
    }
}
