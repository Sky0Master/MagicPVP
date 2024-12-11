using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace VinoUtility{

// [CreateAssetMenu(fileName = "New TransformAnimation", menuName = "SO/TransformAnimation")]
// public class TransformAnimation : ScriptableObject
// {
//     public float duration;
//     public AnimationCurve positionCurve;
//     public AnimationCurve rotationCurve;
//     public AnimationCurve scaleCurve;

//     IEnumerator<WaitForSeconds> SetTransform()
//     {
//         float t = 0;
//         while (t < duration)
//         {
//             t += Time.deltaTime;
//             yield return new WaitForSeconds(Time.deltaTime);
//         }
//     }
//     public void Play(Transform t)
//     {
        
//     }
// }

public static class TransformExt
{

    /// <summary>
    /// 获取从当前Transform指向鼠标位置的2D向量
    /// </summary>
    /// <param name="invoker"></param>
    /// <returns></returns>
    public static Vector2 GetMouseVector2(this Transform invoker)
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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

    public static void RenameChildrenByIndex(this Transform invoker, int startIndex = 0)
    {
        for (int i = 0; i < invoker.childCount; i++)
        {
            invoker.GetChild(i).name = (i + startIndex).ToString();
        }
    }

    public static IEnumerator PlayPositionAnimation(this Transform invoker, AnimationCurve xCurve, AnimationCurve yCurve, AnimationCurve zCurve,float duration = 1f, float factor = 1f)
    {
        float t = 0;
        var x = invoker.position.x;
        var y = invoker.position.y;
        var z = invoker.position.z;
        while (t < duration)
        {
            invoker.position = new Vector3(x + factor * xCurve.Evaluate(t / duration), y + factor * yCurve.Evaluate(t / duration), z + factor * zCurve.Evaluate(t / duration));
            t += Time.deltaTime;
            yield return null;
        }
    }
    public static IEnumerator PlayScaleAnimation(this Transform invoker, AnimationCurve scaleCurve, float duration)
    {
        
        float t = 0;
        var x = invoker.localScale.x;
        var y = invoker.localScale.y;
        var z = invoker.localScale.z;
        while (t < duration)
        {
            invoker.localScale = new Vector3(x * scaleCurve.Evaluate(t / duration),y * scaleCurve.Evaluate(t / duration), z * scaleCurve.Evaluate(t / duration));
            t += Time.deltaTime;
            yield return null;
        }
    }
}
}
