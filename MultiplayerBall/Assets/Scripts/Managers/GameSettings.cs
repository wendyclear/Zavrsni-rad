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
    public string _nickname = "Punfish";

    public string Nickname
    {
        get
        {
            int val = Random.Range(0, 9999);
            return _nickname + val.ToString();
        }
    }
}
