﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickInstantiateCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;

    private void Awake()
    {
        //Vector2 offset = Random.insideUnitCircle * 3f;
        Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        MasterManager.NetworkInstantiate(_prefab, position, Quaternion.identity);
    }
}
