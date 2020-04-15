using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _camera;
    void Update()
    {
        _camera.SetActive(false);
    }

}
