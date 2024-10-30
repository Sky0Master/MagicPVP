using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace VinoUtility{
public static class TransformExt
{

    public static void DestroyAllChildrenEditor(this Transform invoker)
    {
        var pa = (Transform)invoker;
        var children = GetAllChildren(pa);
        foreach (var child in children)
        {
           Undo.DestroyObjectImmediate(child.gameObject);
        }
    }
    public static void MakeChildrenInLine(this Transform invoker, float dist = 1f)
    {
        var pa = (Transform)invoker;
        var children = GetActiveChildren(pa);
        for (int i = 0; i < children.Count; i++)
        {
            children[i].localPosition = new Vector3(dist * i, 0, 0);
        }
    }
    public static List<Transform> GetActiveChildren(this Transform node)
    {
        List<Transform> children = new List<Transform>();
        for(int i = 0; i < node.childCount; i++)
        {
            var child = node.GetChild(i);
            if (child.gameObject.activeSelf)
                children.Add(child);
        }
        return children;
    }
    public static List<Transform> GetInactiveChildren(this Transform node)
    {
        List<Transform> children = new List<Transform>();
        for (int i = 0; i < node.childCount; i++)
        {
            var child = node.GetChild(i);
            if (!child.gameObject.activeSelf)
                children.Add(child);
        }
        return children;
    }
    public static List<Transform> GetAllChildren(this Transform node)
    {
        List<Transform> children = new List<Transform>();
        for (int i = 0; i < node.childCount; i++)
        {
            children.Add(node.GetChild(i));
        }
        return children;
    } 
}
}
