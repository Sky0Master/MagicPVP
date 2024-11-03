using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosineFlyHeight : MonoBehaviour
{
    public float flyHeightOffset = 0.5f;
    public float flyHeightSpeed = 5f;
    public int index = 0;
    // Update is called once per frame
     private void LateUpdate() {
        var yOffset = flyHeightOffset * Mathf.Cos(flyHeightSpeed * Time.time + index * Mathf.PI);
        transform.localPosition = new Vector3(transform.localPosition.x, yOffset, transform.localPosition.z);
    }
    
}
