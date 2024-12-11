using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSkill : MonoBehaviour
{
    public float coolTime = 1f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(MouseSelect.selectedTrans != null)
            {
                transform.position = MouseSelect.selectedTrans.position;
            }
        }
    }
}
