using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalProjectile2D : Projectile2D
{
    public GameObject portalObj;
    public SpriteRenderer bulletSpr;
    public Color portalColor1;
    public Color portalColor2;
    public static int counter = 0;

    protected void SetPortalInfo(Portal2D portal)
    {
        portal.portalId = counter;
        portal.targetPortalId = counter % 2==0 ? counter + 1 : counter - 1;
        portal.GetComponent<SpriteRenderer>().color = counter % 2==0 ? portalColor1 : portalColor2;
        counter++;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        _rb.bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;
        bulletSpr.enabled = false;

        portalObj.SetActive(true);
        portalObj.transform.position = other.contacts[0].point;
        portalObj.transform.up = other.contacts[0].normal;
        SetPortalInfo(portalObj.GetComponent<Portal2D>());
    }
    
}
