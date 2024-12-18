using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VinoUtility.Gameplay;

public class NetEnemyAttack : MonoBehaviour
{
    public float interval = 1.0f;
    public float range = 1f;
    public float damage = 1f;
    // Start is called before the first frame update
    public string targetTag = "Player";
    float _lastAttackTime;
    void Update()
    {
        if(_lastAttackTime + interval > Time.time) return;
        _lastAttackTime = Time.time;
        var res = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (var collider in res)
        {
            if(collider.CompareTag(targetTag) && collider.TryGetComponent<Health>(out var health))
            {
                health.TakeDamage(damage , transform.root.gameObject);
            }

        }
    }
}
