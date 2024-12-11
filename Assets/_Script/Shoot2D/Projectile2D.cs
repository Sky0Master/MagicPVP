using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile2D : MonoBehaviour
{
    public float speed = 1f;
    public float lifeTime = 3f;
    
    float _stTime;
    protected Rigidbody2D _rb;

    bool _hasLaunched = false;

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        _rb.isKinematic = true;
        _rb.Sleep();
    }
    protected virtual void PlayDestroyAnimation()
    {
        
    }
    protected virtual void OnLaunch()
    {

    }
    protected virtual void OnShootUpdate()
    {

    }

    protected virtual void OnDestroy()
    {
        PlayDestroyAnimation();
        
    }
    public void Launch(Vector2 direction)
    {
        OnLaunch();
        _rb.WakeUp();
        _rb.velocity = direction * speed;
        _hasLaunched = true;
        _stTime = Time.time;
        transform.right = direction.normalized;
    }
    
    // Update is called once per frame
    void Update()
    {
        OnShootUpdate();
        if(_hasLaunched && Time.time - _stTime >= lifeTime)
        {
            OnDestroy();
            Destroy(gameObject);
        }
    }
}
