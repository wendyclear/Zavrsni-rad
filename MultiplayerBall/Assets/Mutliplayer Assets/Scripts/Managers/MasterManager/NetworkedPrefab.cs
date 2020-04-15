﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NetworkedPrefab
{
    public GameObject Prefab;
    public string Path;

    public NetworkedPrefab (GameObject obj, string str)
    {
        Prefab = obj;
        Path = ReturnPrefabPathModified(str);
    }

    private string ReturnPrefabPathModified(string path)
    {
        int extentionLength = System.IO.Path.GetExtension(path).Length;
        int additionalLength = 10; // resources/
        int startIndex = path.ToLower().IndexOf("resources");

        if (startIndex == -1) return string.Empty;
        return path.Substring(startIndex + additionalLength, path.Length - (additionalLength + startIndex + extentionLength));
    }

    public string GetPrefabName()
    {
        return Prefab.name;
    }
}
