using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using VinoUtility;

public class NetPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    Rigidbody2D _rig;
    public PlayerInput playerInput;
    private void Start() {
        _rig = GetComponent<Rigidbody2D>();
    }
    void Update() //inputs
    {
        _rig.velocity = playerInput.AxisRaw().normalized * moveSpeed;
    }
}