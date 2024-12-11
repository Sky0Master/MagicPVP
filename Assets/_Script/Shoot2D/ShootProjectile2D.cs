using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using VinoUtility;


public class ShootProjectile2D : MonoBehaviour
{
    [SerializeField]
    protected GameObject projectilePrefab;
    
    public float shootSpeed = 50f;
    // Start is called before the first frame update
    public float shootCoolTime = 0.5f; 
    public Vector2 fireOffset;
    
    [Header("Easy Use Settings")]
    public bool useMouseShoot;
    public KeyCode shootKey;

    private float _lastShootTime;

    [Header("Load from Module")]
    public ShootModule2D shootData;
    public NetProjectile2D Shoot(Vector2 direction)
    {
        if(Time.time <  _lastShootTime + shootCoolTime) return null;
        var obj = NetGameObjectManager.Instance.Generate(projectilePrefab);
        obj.transform.position = GetFirePos();
        var projectile = obj.GetComponent<NetProjectile2D>();
        projectile.Launch(shootSpeed * direction);
        _lastShootTime = Time.time;
        return projectile;
    }
    public NetProjectile2D ShootAt(Vector2 targetPos)
    {
        var firePos = GetFirePos();
        Vector2 dir = (targetPos - firePos).normalized;
        return Shoot(dir);
    }

    public Vector2 GetFirePos()
    {
        return (Vector2)transform.position + fireOffset.x * (Vector2)transform.right  + fireOffset.y * (Vector2)transform.up;
    }
    void Update()
    {
        if(useMouseShoot && Input.GetKeyDown(shootKey))
        {
            Shoot(transform.GetMouseVector2().normalized);    
        }
    }
    
    #if UNITY_EDITOR
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(GetFirePos(), 0.05f);
    }
    private void OnValidate() {
        if(shootData!= null) {
            SetShootData(shootData);
        }
    }
    #endif

    public void SetProjectilePrefab(GameObject prefab)
    {
        projectilePrefab = prefab;
    }
    
    public void SetShootData(ShootModule2D data)
    {
        this.projectilePrefab = data.projectilePrefab;
        this.shootSpeed = data.speed;
        this.shootCoolTime = data.coolTime;
        this.useMouseShoot = data.useMouseShoot;
        this.shootKey = data.shootKey;
    }
}
