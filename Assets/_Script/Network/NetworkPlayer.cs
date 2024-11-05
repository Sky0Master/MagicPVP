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
    
    public Dictionary<NetworkPlayer,string> allPlayers;
    
    [ClientRpc]
    public void UpdatePlayerNameServer(string name, NetworkPlayer netPlayer)
    {
        allPlayers[netPlayer] = name;
    }


    [Command]
    public void SetPlayerNameServer(string name, NetworkPlayer netPlayer)
    {
        UpdatePlayerNameServer(name, netPlayer);
    }

    [Client]
    public void SetPlayerName(string name)
    {
        //不能改非本地玩家的名字
        if(!isLocal)
            return;
        playerName = name;
        SetPlayerNameServer(name, this);
    }
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
