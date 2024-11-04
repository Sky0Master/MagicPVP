using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using Steamworks;
using UnityEngine.UI;
public class UISteamLobby : NetworkBehaviour
{
    [SerializeField]
    GameObject _playerCardPrefab;

    [SerializeField]
    Transform _playerList;

    Dictionary<string, GameObject> _playerCards = new Dictionary<string, GameObject>();
    
    //[ClientRpc]
    public void AddNewPlayerDisplay(CSteamID steamId, string name)
    {
        if(_playerCards.ContainsKey(steamId.ToString()))
        {
            _playerCards[steamId.ToString()].SetActive(true);
            return;
        }

        //同步创建玩家卡片
        GameObject card = Instantiate(_playerCardPrefab, _playerList);
        NetworkServer.Spawn(card);

        //设置name
        card.GetComponentInChildren<TextMeshProUGUI>().text = name;
        
        //设置头像
        var avatarTexture = GetAvatar(steamId);
        var spr = Sprite.Create(avatarTexture,new Rect(0, 0, avatarTexture.width, avatarTexture.height),Vector2.one * 0.5f);
        card.GetComponentInChildren<Image>().sprite = spr;
        
        _playerCards.Add(steamId.ToString(), card); 
    }
    Texture2D GetAvatar(CSteamID steamId)
    {
        int largeAvatarHandle = SteamFriends.GetLargeFriendAvatar(steamId);
        if (largeAvatarHandle != 0)
        {
            uint width, height;
            SteamUtils.GetImageSize(largeAvatarHandle, out width, out height);
            byte[] avatarBytes = new byte[width * height * 4];
            SteamUtils.GetImageRGBA(largeAvatarHandle, avatarBytes, avatarBytes.Length);
            Texture2D avatarTexture = new Texture2D((int)width, (int)height);
            avatarTexture.LoadImage(avatarBytes);
            return avatarTexture;
        }
        return null;
    }

}
