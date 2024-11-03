using System.Collections;
using System.Collections.Generic;
using Mirror;
using ParrelSync;
using UnityEngine;
using VinoUtility;

public class ProjectileMagic : Magic
{
    [SerializeField]
    GameObject _projectilePrefab;

    [SerializeField]
    Transform _generatePos;

    Vector2 _direction;
    
    protected override void MagicStart()
    {
        _direction = transform.GetMouseVector2().normalized;
        GenerateProjectile(_generatePos.position, _direction);
        _living = false;
    }
    private void PlayAnimation()
    {
        
    }
    [Command]
    public void GenerateProjectile(Vector2 pos, Vector2 dir)
    {
        var go = Instantiate(_projectilePrefab);
        go.transform.position = pos;
        go.transform.right = dir;
        var p = go.GetComponent<Projectile2D>();
        p.Lauch(dir);
    }
}
