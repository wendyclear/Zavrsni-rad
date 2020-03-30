using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenu(menuName = "Singletons/MasterManager")]

public class MasterManager : SingletonScriptableObject<MasterManager>
{
    [SerializeField]
    private GameSettings _gameSettings;
    public static  GameSettings GameSettings { get{  return Instance._gameSettings;}}

    [SerializeField]
    private List<NetworkedPrefab> _networkedPrefabs = new List<NetworkedPrefab>();

    public static GameObject NetworkInstantiate(GameObject obj, Vector3 position, Quaternion rotation)
    {

       foreach (NetworkedPrefab networkedPrefab in Instance._networkedPrefabs)
        {
            //check if object matches with prefab NetwrokedPrefab and then place it and return
            if (networkedPrefab.Prefab == obj)
            {
                if (networkedPrefab.Path != string.Empty)
                {
                    GameObject result = PhotonNetwork.Instantiate(networkedPrefab.Path, position, rotation);
                    return result;
                }
                else
                {
                    Debug.LogError("Path is empty for gameobject name : " + networkedPrefab.Prefab);
                    return null;
                }
            }
        }
        return null;
    }

    //ALWAYS KEEP THIS METHOD PUBLIC
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)] //only works in editor, at least one PLAY before build
    public static void PopulateNetworkedPrefabs()
    {
#if UNITY_EDITOR
        Instance._networkedPrefabs.Clear();
        //runs only 
        
        GameObject[] results = Resources.LoadAll<GameObject>("");
        for (int i = 0; i<results.Length; i++)
        {
            if (results[i].GetComponent<PhotonView>() != null)
            {
                string path = AssetDatabase.GetAssetPath(results[i]);
                // STATIC methods dont recongize variables outside
                Instance._networkedPrefabs.Add(new NetworkedPrefab(results[i], path));
            }
        }
#endif
    }

}
