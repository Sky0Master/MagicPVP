using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VinoUtility;

public class MouseSelect : MonoBehaviour
{

    public float range = 3f;
    public static Transform selectedTrans;
    public static int availableCount;
    public GameObject highlight;

    public bool isSelected;

    public void UpdateSelected()
    {
        var dist = transform.GetMouseVector2().magnitude;
        if(dist > range)
        {
            if(selectedTrans == transform)
                selectedTrans = null;
            return;
        }
        if(selectedTrans == null)
        {
            selectedTrans = transform;
            isSelected = true;
        }
        else{
            var oldDist = selectedTrans.GetMouseVector2().magnitude;
            isSelected = dist <= oldDist;
            selectedTrans = isSelected ? transform : selectedTrans;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        UpdateSelected();
        highlight.SetActive(isSelected);
    }
    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    #endif
}
