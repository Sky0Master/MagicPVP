using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class TeamInfo : NetworkBehaviour 
{    
    public static Dictionary<NetworkPlayer, TeamInfo> teamInfos = new Dictionary<NetworkPlayer, TeamInfo>();
    [SyncVar]
    public int teamId;
    
    [SyncVar]
    public Color teamColor;
    
    private void Start() {
        if(isLocalPlayer)
        {
            
        }
    }
}
