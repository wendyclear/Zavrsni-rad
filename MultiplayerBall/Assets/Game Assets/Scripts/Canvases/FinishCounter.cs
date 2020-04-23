using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCounter : MonoBehaviourPun
{
    [SerializeField]
    private int _playerCount;

    private void Start()
    {
        Initialize();
    }
    private void Initialize()
    {
        _playerCount = 0;
    }

    public int Finish()
    {
        _playerCount += 1;
        return _playerCount;
    }


}
