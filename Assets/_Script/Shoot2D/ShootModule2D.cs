using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shoot Data", menuName = "Shoot Data", order = 1)]
public class ShootModule2D : ScriptableObject
{
    public float speed;
    public float coolTime;
    public GameObject projectilePrefab;
    public bool useMouseShoot;
    public KeyCode shootKey = KeyCode.Mouse0;
}
