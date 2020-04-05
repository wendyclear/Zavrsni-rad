using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCustomPropertyGenerator : MonoBehaviour
{
    [SerializeField]
    private Text _text;
    private ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();

    private void SetCustomNumber()
    {
        System.Random rnd = new System.Random();
        int result = rnd.Next(0, 99);
        _text.text = result.ToString();

        _myCustomProperties["RandomNumber"] = result;
        // _myCustomProperties.Remove("RandomNumber");
        PhotonNetwork.SetPlayerCustomProperties(_myCustomProperties); //guchi
        //PhotonNetwork.LocalPlayer.CustomProperties = _myCustomProperties; //not guchi
    }
    public void OnClick_Button()
    {
        SetCustomNumber();
    }
}
