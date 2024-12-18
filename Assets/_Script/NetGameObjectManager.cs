using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class NetGameObjectManager : NetworkBehaviour
{
    public static NetGameObjectManager Instance { get; private set;}
    private void Awake() {
        if(Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }
    public bool isNetworkGame;
    // Start is called before the first frame update
    public GameObject Create(GameObject prefab)
    {
        var go = Instantiate(prefab);
        if(isNetworkGame)
        {
            NetworkServer.Spawn(go);
        }
        return go;
    }
    public void Delete(NetworkIdentity identity)
    {
        NetworkServer.Destroy(identity.gameObject);
    }
}
