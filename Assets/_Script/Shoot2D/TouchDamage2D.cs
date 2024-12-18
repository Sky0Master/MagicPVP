using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Mirror;

namespace VinoUtility.Gameplay
{
public class TouchDamage2D : MonoBehaviour
{
    public int damage;
    public List<string> exceptTags;
    public GameObject damageSource;

    [Header("Touch Event")]
    public UnityEvent touchEvent;
    public bool destroyAfterTouch = true;
    public float destroyDelay = 0.0f;



    private void OnTriggerEnter2D(Collider2D other) {
        if(exceptTags.Contains(other.tag))
            return;
        
        var health = other.GetComponent<Health>();
        if(health==null)
            health = GetComponentInParent<Health>();
        if(health==null)
            return;
        
        if(damageSource==null)
            damageSource = gameObject;
        health.TakeDamage(damage, damageSource);
        if(destroyAfterTouch)
            Invoke("Destruct", destroyDelay);
    }
    public void Destruct()
    {
        NetGameObjectManager.Instance.Delete(GetComponent<NetworkIdentity>());
    }
}
}