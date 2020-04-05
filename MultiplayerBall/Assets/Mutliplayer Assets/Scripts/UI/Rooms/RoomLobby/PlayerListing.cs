using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListing : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _text;
    public bool Ready = false;

    public Player Player { get; private set; } //znači da se može getat svugdje, ali set samo u skripti

    public void SetPlayerInfo(Player player)
    {
        Player = player;
        SetPlayerText(Player);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (targetPlayer != null && targetPlayer == Player)
        {
            if (changedProps.ContainsKey("RandomNumber"))
            {
                SetPlayerText(Player);
            }
        }
    }

    private void SetPlayerText(Player player)
    {
        int result;
        if (player.CustomProperties.ContainsKey("RandomNumber"))
        {
            result = (int)player.CustomProperties["RandomNumber"];
        }
        else
        {
            result = -1;
        }
        //_text.text = result.ToString() + ", " + player.NickName;
        _text.text = player.NickName;
    }
}
