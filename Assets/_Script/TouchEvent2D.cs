using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchEvent2D : MonoBehaviour
{
    public UnityEvent onTouch;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            onTouch?.Invoke();
        }
    }
    
}
