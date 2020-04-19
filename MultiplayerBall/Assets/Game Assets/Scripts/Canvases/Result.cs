using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField]
    private Text _resultText;

    public void SetResult(int result)
    {
        _resultText.text = "Your result : " + result.ToString();
    }
}
