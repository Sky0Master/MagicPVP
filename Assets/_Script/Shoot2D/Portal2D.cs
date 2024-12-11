using System.Collections.Generic;
using UnityEngine;

public class Portal2D : MonoBehaviour
{
    public int portalId;
    public static Dictionary<int, Vector2> PortalDict = new Dictionary<int, Vector2>();
    public int targetPortalId;

    public Vector2 portalOffset = Vector2.zero;

    #if UNITY_EDITOR
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere((Vector2)transform.position + portalOffset, 0.05f);
    }
    #endif

    public void Portal(Transform passenger)
    {
        if(PortalDict.ContainsKey(targetPortalId))
            passenger.transform.position = PortalDict[targetPortalId];
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Portal(other.gameObject.transform);
    }

    private void FixedUpdate() {
        PortalDict[portalId] = (Vector2)transform.position + portalOffset;
    }
}
