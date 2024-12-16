using Mirror;
using Steamworks;
using UnityEngine;

public class SteamLobby : MonoBehaviour
{
    public GameObject hostBtn;

    public UISteamLobby uISteamLobby;

    // Calback监听Steamworks是否创建大厅
    protected Callback<LobbyCreated_t> lobbyCreated;
    // 在Steam上邀请加入游戏或直接加入游戏时都会触发该Callback
    protected Callback<GameLobbyJoinRequested_t> gameLobbyJoinRequested;
    // 监听玩家进入大厅
    protected Callback<LobbyEnter_t> lobbyEnter;

    private NetworkManager networkManager;
    private const string HostAddressKey = "HostAddress";

    private void Start()
    {
        networkManager = GetComponent<NetworkManager>();

        if (!SteamManager.Initialized) { return; }

        // 2. 定义监听，当发生了大厅创建Callback事件后，要调用什么函数
        lobbyCreated = Callback<LobbyCreated_t>.Create(OnLobbyCreated);
        gameLobbyJoinRequested = Callback<GameLobbyJoinRequested_t>.Create(OnGameLobbyJoinRequested);
        lobbyEnter = Callback<LobbyEnter_t>.Create(OnLobbyEnter);
        //Callback<LobbyKicked_t>.Create(OnLobbyKicked);
    }

    // 1. 按钮点击，开始创建大厅
    public void HostLobby()
    {
        hostBtn.SetActive(false);
        SteamMatchmaking.CreateLobby(ELobbyType.k_ELobbyTypeFriendsOnly, networkManager.maxConnections);
    }

    // 3. 无论大厅成功创建与否，都会调用此函数
    // LobbyCreated_t参数为必要项，传入全部关于大厅的数据
    private void OnLobbyCreated(LobbyCreated_t callback)
    {
        // 如果大厅创建失败，重新显示按钮
        if (callback.m_eResult != EResult.k_EResultOK)
        {
            hostBtn.SetActive(true);
            Debug.LogError("Lobby create failed.");
            return;
        }

        // 成功时，在Mirror上成为Host
        // 使用Mirror进行普通传输，IP地址将作为网络地址
        // 使用Steam传输时，传输的是Steam ID
        networkManager.StartHost();

        // 任何进入大厅的人，都可以通过获取HostAddressKey，来获取我们的SteamID
        // 参数一：告知Steam大厅的ID (CSteamID类型)
        // 参数二：传入一个Key，指向Value，类似字典的作用
        // 参数三：传入一个Value，大厅所有者的SteamID
        SteamMatchmaking.SetLobbyData(
            new CSteamID(callback.m_ulSteamIDLobby),
            HostAddressKey,
            SteamUser.GetSteamID().ToString());

        uISteamLobby.AddNewPlayerDisplay(SteamUser.GetSteamID(), SteamFriends.GetPersonaName());
        
        // networkManager.StartClient();
        // NetworkClient.AddPlayer();
        //Debug.LogError("Lobby created.");
    }

    private void OnGameLobbyJoinRequested(GameLobbyJoinRequested_t callback)
    {
        // 传入Lobby ID
        SteamMatchmaking.JoinLobby(callback.m_steamIDLobby); 
    }

    private void OnLobbyEnter(LobbyEnter_t callback)
    {
        // 如果是主机，直接返回
        if (NetworkServer.active) { 
            return; 
        }

        string playerName = SteamFriends.GetPersonaName();
        string playerID = SteamUser.GetSteamID().ToString();
        uISteamLobby.AddNewPlayerDisplay(SteamUser.GetSteamID(), playerName);
        Debug.LogError($"Player {playerName}({playerID}) joined the lobby!");

        // 如果是客户，从Lobby数据中获取HostAddress
        string hostAddress = SteamMatchmaking.GetLobbyData(
            new CSteamID(callback.m_ulSteamIDLobby),
            HostAddressKey);

        // 在Mirror中设置HostAddress，开启客户端，客户端将使用Steam传输连接到该地址
        networkManager.networkAddress = hostAddress;
        networkManager.StartClient();

        hostBtn.SetActive(false);

        uISteamLobby.AddNewPlayerDisplay(SteamUser.GetSteamID(), playerName);

        //添加client角色
        NetworkClient.AddPlayer();
    }
}
