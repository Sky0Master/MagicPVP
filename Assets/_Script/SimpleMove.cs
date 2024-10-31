using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 8f;

    public Rigidbody2D rb;

    float inputHorizontal;
    float inputVertical;

    void Update() //inputs
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(inputHorizontal, inputVertical).normalized * moveSpeed;
    }
}