using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TransformUtilityEditor : MonoBehaviour
{
    [MenuItem("Custom/Place Player or Selected to View")]
    public static void Place()
    {
        SceneView sceneView = SceneView.lastActiveSceneView;

        Transform target = Selection.activeTransform;
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player").transform;     
        if (target == null) return;
        target.transform.position = new Vector3(sceneView.pivot.x, target.transform.position.y, 0);
        EditorUtility.SetDirty(target);
    }

    [MenuItem("Custom/Sort Children Hierachy by X")]
    public static void Sort()
    {
        int childCount = Selection.activeGameObject.transform.childCount;
        List<Transform> children = new List<Transform>();
        for (int i = 0; i < childCount; i++)
        {
            children.Add(Selection.activeGameObject.transform.GetChild(i));
        }

        children.Sort((a, b) => a.position.x.CompareTo(b.position.x));

        for (int i = 0; i < children.Count; i++)
        {
            children[i].SetSiblingIndex(i);
            EditorUtility.SetDirty(children[i]);
        }
    }
}
