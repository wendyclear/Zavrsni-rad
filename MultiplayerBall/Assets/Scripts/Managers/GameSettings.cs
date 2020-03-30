using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Manager/GameSettings")]
public class GameSettings : ScriptableObject
{
    //setting up the photon
    [SerializeField]
    private string _gameVersion = "0.0.0";

    public string GameVersion { get { return _gameVersion;}}

    [SerializeField]
    public string _nickname;

    public void Awake()
    {
        if (!string.IsNullOrEmpty(UserManager.UM.GetUsername()))
        {
            _nickname = UserManager.UM.GetUsername();
        }
        else
        {
            _nickname = "Sara";
        }
    }

    public string Nickname
    {
        get
        {
            return _nickname;
        }
    }
}
