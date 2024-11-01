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
        
        lastUseTime = Time.time;
        _living = true;
        MagicStart();
    }
    protected virtual void MagicStart()
    {

    }
    protected virtual void MagicUpdate()
    {

    }
    void Start()
    {
        MagicStart();
    }
    void Update()
    {
        if(_living)
            MagicUpdate();
        if(Time.time - lastUseTime > coolTime)
        {
            available = true;
        }
        
    }

}
