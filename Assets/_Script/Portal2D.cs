using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2D : MonoBehaviour
{
    public int portalId;
    public static Dictionary<int, Transform> PortalDict = new Dictionary<int, Transform>();
    public int targetPortalId;
    private void Awake() {
        PortalDict[portalId] = transform;
    }
    public void Portal(Transform passenger)
    {
        if(PortalDict.ContainsKey(targetPortalId))
            passenger.transform.position = PortalDict[targetPortalId].position;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Portal(other.gameObject.transform);
    }
}
