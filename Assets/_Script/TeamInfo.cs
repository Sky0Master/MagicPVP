using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class TeamInfo : NetworkBehaviour 
{
    [SyncVar]
    public int teamId;

    public override void OnStartServer()
    {
        base.OnStartServer();
    }
    // Start is called before the first frame update
    void Start()
    {
        if(!isLocalPlayer)
        {
            
            
        }
    }
}
