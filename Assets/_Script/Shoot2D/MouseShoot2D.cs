using UnityEngine;
using VinoUtility;

public class MouseShoot2D : MonoBehaviour
{
    public float speed = 10f;
    public bool canShoot = true;
    public float liveTime = 5f;
    private float _shootTime;
    public AnimationCurve speedCurve;
    public bool useRightButton = false;
    public void Shoot(GameObject projectile, Vector2 velocity)
    {
        projectile.transform.SetParent(null);
        transform.right = velocity.normalized;
        var rig = projectile.GetComponent<Rigidbody2D>();
        rig.isKinematic = true;
        StartCoroutine(LerpUtility.Lerp(0,liveTime,liveTime,(t)=>{
            speed = speedCurve.Evaluate(t);
            rig.velocity = velocity * speed;
        }));
    }
    // Update is called once per frame
    void Update()
    {
        var key = useRightButton? KeyCode.Mouse1 : KeyCode.Mouse0;
        if(canShoot && Input.GetKeyDown(key))
        {
            canShoot = false;
            _shootTime = Time.time;
            Shoot(gameObject, transform.GetMouseVector2().normalized * speed);
        }
        if(!canShoot && Time.time - _shootTime > liveTime)
        {
            Destroy(gameObject);
        }

    }
}
