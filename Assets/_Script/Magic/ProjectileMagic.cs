using System.Collections;
using System.Collections.Generic;
using Mirror;
using ParrelSync;
using UnityEngine;

public class ProjectileMagic : Magic
{
    [SerializeField]
    GameObject _projectilePrefab;

    [SerializeField]
    Transform _generatePos;

    Vector2 _direction;
    
    protected override void MagicStart()
    {
        var p = GenerateProjectile(_generatePos.position, Vector2.right);
        
    }
    [Command]
    public Projectile2D GenerateProjectile(Vector2 pos, Vector2 dir)
    {
        var go = Instantiate(_projectilePrefab);
        go.transform.position = pos;
        go.transform.right = dir;
        var p = go.GetComponent<Projectile2D>();
        p.Lauch(dir);
        return p;
    }
}
