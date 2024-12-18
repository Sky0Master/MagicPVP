using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetTracePlayer : MonoBehaviour
{
    public float detectRange = 10f;
    public float speed = 5f;
    public float stopDistance = 0.1f;

    public bool alwaysFacePlayer = false;
    
    public string traceTag = "Player";
    // Start is called before the first frame update
    Transform _target;

    #if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
    #endif

    private void FixedUpdate() {
        var resList = Physics2D.OverlapCircleAll(transform.position,  detectRange);
        _target = null;
        foreach (var res in resList)
        {
            if(!res.gameObject.CompareTag(traceTag)) 
                continue;

            if(_target == null)
            {
                _target = res.transform;
            }
        }

        if(_target!= null && Vector3.Distance(transform.position, _target.position) > stopDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position ,_target.position,speed * Time.deltaTime);
        }
    }
}
