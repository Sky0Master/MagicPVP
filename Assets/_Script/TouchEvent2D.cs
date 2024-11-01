using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchEvent2D : MonoBehaviour
{
    public UnityEvent onTouch;
    public string touchTag = "Player";

    private void OnTriggerEnter2D(Collider2D other) {
        if(touchTag == "" || other.tag == touchTag)
        {
            onTouch?.Invoke();
        }
    }
    
}
