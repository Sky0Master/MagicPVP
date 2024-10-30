using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance {
        get;
        private set;
    }
    protected void Awake() {
        if(Instance == null){
            Instance = GetComponent<T>();
        }
        else{
            Destroy(this.gameObject);
            return;
        }
    }
}
