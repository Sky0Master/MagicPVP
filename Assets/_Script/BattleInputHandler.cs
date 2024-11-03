using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using VinoUtility;
public class BattleInputHandler : NetworkBehaviour
{
    MagicHandler magicHandler;
    Transform weaponTrans;
    private void Start() {
        magicHandler = GetComponent<MagicHandler>();
        
    }
    void Update()
    {
        if(!isLocalPlayer) return;
        if(Input.GetMouseButtonDown(0))
        {
            magicHandler.UseMagic();
            weaponTrans.right = transform.GetMouseVector2().normalized;
        }
    }
}
