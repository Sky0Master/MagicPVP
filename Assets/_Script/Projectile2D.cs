using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

[RequireComponent(typeof(NetworkRigidbodyReliable2D))]
public class Projectile2D : NetworkBehaviour
{
    public float speed = 1f;
    public float duration = 3f;
    
    float _stTime;
    Rigidbody2D _rb;
    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        _rb.isKinematic = true;
        _rb.Sleep();
    }
    protected virtual void OnShoot()
    {

    }
    protected virtual void OnDestroy()
    {
        
    }

    
    public void Lauch(Vector2 direction)
    {
        OnShoot();
        _rb.WakeUp();
        _rb.velocity = direction * speed;
        
    }

    void Update()
    {
        if(Time.time - _stTime >= duration)
        {
            OnDestroy();
            Destroy(gameObject);
        }
    }
}
