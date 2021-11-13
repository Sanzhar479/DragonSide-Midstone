using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected float speed;

    protected Rigidbody2D rb;
    protected int direction;
    private void Start()
    {
        //it initializes the starting velocity of the projectile
        rb = GetComponent<Rigidbody2D>();

        var force = rb.transform.right * speed;
        rb.velocity = force;
    }
}
