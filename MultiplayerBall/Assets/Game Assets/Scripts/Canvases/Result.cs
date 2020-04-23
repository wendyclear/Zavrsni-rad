using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField]
    private Text _resultText;
    [SerializeField]
    private Text _placeText;


    public void SetResult(int result)
    {
        _resultText.text = "Your result : " + result.ToString();
    }

    public void SetPlace(int place)
    {
        _placeText.text = "Your place : " + place.ToString();
    }
}
