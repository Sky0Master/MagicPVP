using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchShootModule : MonoBehaviour
{
    [SerializeField]
    ShootProjectile2D shootHandler;
    
    public List<ShootModule2D> shootModules;
    
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < shootModules.Count; i++)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                shootHandler.SetShootData(shootModules[i]);
            }
        }
    }
}
