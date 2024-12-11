using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class DisableOnRemotePlayer : NetworkBehaviour
{
    public bool disableGameObject;
    public bool destroyGameObject;
    public bool disableScripts;
    public List<MonoBehaviour> scriptsToDisable;
    void Start()
    {
        if(!isLocalPlayer)
        {
            
            if(disableGameObject)
                this.gameObject.SetActive(false);
            
            if(disableScripts)
            {
                foreach(MonoBehaviour script in scriptsToDisable)
                {
                    script.enabled = false;
                }
            }

            if(destroyGameObject)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
