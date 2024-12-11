using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class DisableOnRemotePlayer : NetworkBehaviour
{
    public bool destroy;
    void Start()
    {
        if(!isLocalPlayer)
        {
            this.gameObject.SetActive(false);
            if(destroy)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
