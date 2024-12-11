using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[RequireComponent(typeof(NetworkIdentity))]
[RequireComponent(typeof(TeamInfo))]
public class NetworkPlayer : NetworkBehaviour
{

    public string playerName;
    public bool isLocal = false;

    
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        isLocal = true;
        gameObject.tag = "Player";
    }

    public void QuitGame()
    {
        
    }
}
