using UnityEngine;
using VinoUtility;

public class RotateTowardsMouse : MonoBehaviour
{
    public float radius = 0;
    public Transform pivot;

    #if UNITY_EDITOR
    private void OnValidate() {
        if (pivot == null) {
            pivot = transform.parent;
        }
        transform.position = pivot.position + Vector3.right * radius;
    }
    #endif
    // Update is called once per frame
    void Update()
    {
        var direction = (Vector3) pivot.GetMouseVector2().normalized;
        transform.position = pivot.position + direction * radius;
        transform.right = direction;
    }
}
