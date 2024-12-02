using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMagic
{
    //目标位置, 施法者的队伍ID
    public void Cast(Vector3 targetPosition, int teamId);
}
