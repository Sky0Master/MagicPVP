using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using VinoUtility;
public class NetGun : NetworkBehaviour
{
    public PlayerInput playerInput;
    public ShootProjectile2D shoot1;
    public ShootProjectile2D shoot2;

    // Update is called once per frame
    void Update()
    {
        if(playerInput.Fire1 && shoot1 != null)
        {
            shoot1.Shoot(transform.GetMouseVector2().normalized);
        }
        if(playerInput.Fire2 && shoot2 != null)
        {
            shoot2.Shoot(transform.GetMouseVector2().normalized);
        }

    }
}
