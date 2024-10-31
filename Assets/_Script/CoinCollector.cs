using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int curPoint = 0;
    public float pickRadius = 1.1f;


    // Update is called once per frame
    void Update()
    {
        var coinCollider = Physics2D.OverlapCircle(transform.position, pickRadius);
        if(coinCollider != null)
        {
            var coin = coinCollider.GetComponent<Coin>();
            if(coin != null)
            {
                curPoint += coin.value;
                Destroy(coin.gameObject);
            }
        }

    }
}
