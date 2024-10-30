using UnityEngine;


namespace VinoUtility{
public static class MathUtils
{

    public static float SmoothStep(float from,float to,float t)
    {
        t = Mathf.Clamp01(t);
        float v1 = t * t;
        float v2 = 1 - (1-t) *(1-t);
        return Mathf.Lerp(from,to, Mathf.Lerp(v1,v2,t));
    }
    public static Vector3 SmoothStep(Vector3 from,Vector3 to,float t)
    {
        t = Mathf.Clamp01(t);
        float v1 = t * t;
        float v2 = 1 - (1-t) *(1-t);
        return Vector3.Lerp(from,to, Mathf.Lerp(v1,v2,t));
    }

    //需要每帧插值计算平滑跟随时使用
    public static Vector3 SmoothFollow(Vector3 current,Vector3 target,float k,float frameTime)
    {
        k = 1 - Mathf.Pow(k,frameTime);
        return Vector3.Lerp(current,target,k);
    }

    public static Vector2 RotateVector2(Vector2 vec,float angle)
    {
        return new Vector2(vec.x * Mathf.Cos(angle) - vec.y * Mathf.Sin(angle), vec.x *  Mathf.Sin(angle) + vec.y * Mathf.Cos(angle));
    }
    public static Vector2 QuadraticCurve(Vector2 p0, Vector2 p1, Vector2 p2, float t)
    {
        Vector2 a = Vector2.Lerp(p0, p1, t);
        Vector2 b = Vector2.Lerp(p1, p2, t);
        return Vector2.Lerp(a, b, t);
    }
    public static Vector2 CubicCurve(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t)
    {
        Vector2 a = QuadraticCurve(p0, p1, p2, t);
        Vector2 b = QuadraticCurve(p1, p2, p3, t);
        return Vector2.Lerp(a, b, t);
    }

    public static Vector3 QuadraticCurve(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        Vector3 a = Vector3.Lerp(p0, p1, t);
        Vector3 b = Vector3.Lerp(p1, p2, t);
        return Vector3.Lerp(a, b, t);
    }

    public static Vector3 CubicCurve(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        Vector3 a = QuadraticCurve(p0, p1, p2, t);
        Vector3 b = QuadraticCurve(p1, p2, p3, t);
        return Vector3.Lerp(a, b, t);
    }
    
    public static Vector2 GetRandomCurvePoint(Vector2 st,Vector2 ed,float angleLimit = 60f)
    {
        return  st + RotateVector2((ed-st) * Random.Range(-1f,1f),Random.Range(-angleLimit,angleLimit));
    }
}
}