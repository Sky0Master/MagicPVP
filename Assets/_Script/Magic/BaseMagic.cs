using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Magic : NetworkBehaviour {
    public string magicName;
    public int cost;
    public float coolTime;
    protected float lastUseTime;
    public bool available;

    protected bool _living;

    /// <summary>
    /// 外部使用魔法时调用
    /// </summary>
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

    /// <summary>
    /// 在释放魔法的那一帧调用
    /// </summary>
    protected virtual void MagicStart()
    {   
    }

    /// <summary>
    /// 在魔法存活的每一帧调用
    /// </summary>
    protected virtual void MagicUpdate()
    {
    }

    /// <summary>
    /// 在魔法存活的最后一帧调用
    /// </summary>
    protected virtual void MagicEnd()
    {
        _living = false;
    }
    void FixedUpdate()
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
