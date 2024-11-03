using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace VinoUtility{
public static class TransformExt
{
    /// <summary>
    /// 获取从当前Transform指向鼠标位置的2D向量
    /// </summary>
    /// <param name="invoker"></param>
    /// <returns></returns>
    public static Vector2 GetMouseVector2(this Transform invoker)
    {
        var pos = Camera.current.ScreenToWorldPoint(Input.mousePosition);
        return (Vector2)pos - (Vector2)invoker.position;
    }
    public static void DestroyAllChildrenEditor(this Transform invoker)
    {
        var pa = invoker;
        var children = GetAllChildren(pa);
        foreach (var child in children)
        {
           Undo.DestroyObjectImmediate(child.gameObject);
        }
    }
    public static void MakeChildrenInLine(this Transform invoker, float dist = 1f)
    {
        var pa = invoker;
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
