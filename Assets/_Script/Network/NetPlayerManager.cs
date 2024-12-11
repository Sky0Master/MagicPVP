
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetPlayerManager : NetworkBehaviour
{
    public static NetPlayerManager Instance;
    private void Awake() {
        if(Instance != null) 
        {   
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    
    public  Dictionary<string,NetworkIdentity> playerDict = new Dictionary<string,NetworkIdentity>();
    public  int teamCount = 0;
    public Dictionary<string, int> teamInfoDict = new Dictionary<string, int>();

    [Command]
    public void RegisterPlayer(string playerName, NetworkIdentity playerIdentity)
    {
        if(playerDict.ContainsKey(playerName))
            return;
        var id = teamCount++;
        SetTeam(playerName, id);
    }
    [Command]
    public void UnRegisterPlayer(string playerName)
    {
        if(playerDict.ContainsKey(playerName))
        {
            playerDict.Remove(playerName);
            teamInfoDict.Remove(playerName);
        }
    }
    [Server]
    public void SetTeam(string playerName, int team)
    {
        teamInfoDict[playerName] = team;
        playerDict[playerName].GetComponent<TeamInfo>().teamId = team;
    }
    [Command]
    public void ChangeTeam(string playerName, int team)
    {
        if(teamInfoDict.ContainsKey(playerName))
        {
            SetTeam(playerName, team);
        }
    }
    
}
