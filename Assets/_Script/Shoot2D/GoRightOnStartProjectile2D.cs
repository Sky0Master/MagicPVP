using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoRightOnStartProjectile2D : NetProjectile2D
{
    public bool randomSpeed = false;
    public float minSpeed = 1f;
    public float maxSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
       if(randomSpeed)
            speed = Random.Range(minSpeed, maxSpeed);
       Launch(transform.right);
    }

}
