using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameCanvas : MonoBehaviour
{
    public GameObject WarningText;
    public Text PlayerName;

    public void OnClick_LoadScene()
    {
        if (string.IsNullOrEmpty(PlayerName.text))
        {
            WarningText.SetActive(true);
        }
        else
        {
            UserManager.UM.SetUsername(PlayerName.text);
            SceneManager.LoadScene("Lobby");
        }
    }
}
