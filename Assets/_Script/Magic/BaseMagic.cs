using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Magic : NetworkBehaviour {
    public string magicName;
    public int cost;
    public float coolTime;
    float lastUseTime;
    public bool available;

    bool _living;

    public void Use()
    {
        if(!available)
            return;
        lastUseTime = Time.time;
        _living = true;
        MagicStart();
    }
    private void OnEnable() {
        lastUseTime = Time.time - coolTime;
    }
    protected virtual void MagicStart()
    {   
    }
    protected virtual void MagicUpdate()
    {
    }
    protected virtual void MagicEnd()
    {
        _living = false;
    }
    void Update()
    {
        if(_living)
            MagicUpdate();
            
        if(Time.time - lastUseTime > coolTime)
        {
            available = true;
        }
        else
        {
            available = false;
        }
        
    }

}
