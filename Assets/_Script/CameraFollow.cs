using System.Collections.Generic;
using UnityEngine;

namespace VinoUtility{

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public string TargetTag = "Player";
    // public float SmoothTime;
    [SerializeField]
    float SmoothSpeed = 0.7f;
    bool _isFollow = true;

    Camera _cam;
    void Start()
    {
        _cam = GetComponent<Camera>();
        if(Target == null){
            Target = GameObject.FindWithTag(TargetTag).transform;
        }
    }

    IEnumerator<WaitForSeconds> FocusOn(Transform focusTarget, float switchDuration, float focusDuration, float zoomSize, bool isFollow)
    {
        StopFollow();
        float t = 0f;
        Vector3 fromPos = transform.position;
        Transform preTarget = Target;
        float fromSize = _cam.orthographicSize;
        while(t < switchDuration)
        {
            t += Time.deltaTime;
            
            //move
            Vector3 newPos = MathUtils.SmoothStep(fromPos,focusTarget.transform.position,t/switchDuration);
            transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);

            //zoom
            _cam.orthographicSize = Mathf.SmoothStep(fromSize, zoomSize, t/switchDuration);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        
        float focus = 0;
        if(isFollow)
        {
            SetTarget(focusTarget);
            StartFollow();
        }
        while(focus < focusDuration)
        {
            focus += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        t = 0;
        while(t < switchDuration)
        {
            t += Time.deltaTime;
            _cam.orthographicSize = Mathf.SmoothStep(zoomSize, fromSize, t);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        if(isFollow)
        {
            SetTarget(preTarget);
        }
        StartFollow();   
    }


    public void FocusOnForTime(Transform target, float switchDuration, float focusDuration, float zoomSize, bool isFollow = true)
    {
        StartCoroutine(FocusOn(target, switchDuration, focusDuration, zoomSize,isFollow));
    }
    public void SetTarget(Transform target)
    {
        Target = target;
    }
    public void StartFollow()
    {
        _isFollow = true;
    }
    public void StopFollow()
    {
        _isFollow = false;
    }
    private void LateUpdate() {
        
        if(Target && _isFollow)
        {
            //Legacy
            //Vector3 newPos = Vector3.Lerp(transform.position, Target.transform.position, SmoothSpeed*Time.fixedDeltaTime);
            Vector3 newPos = MathUtils.SmoothFollow(transform.position,Target.transform.position,SmoothSpeed,Time.deltaTime);
            transform.position = new Vector3(newPos.x, newPos.y, transform.position.z);
        }
    }
}
}