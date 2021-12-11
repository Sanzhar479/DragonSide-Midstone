using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creture : MonoBehaviour
{
    private Vector2 direction = new Vector2(0.0f, 0.0f);
    //Current corutine and state of the mob
    protected Rigidbody2D rb;
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    //Set direction of the creature outside the script
    public void SetDirection(Vector2 dir)
    {
        direction = dir;
    }
    //If creature nmoving to spesific point
    public void SetDirectionTo(Vector2 trans)
    {
        direction = new Vector2(trans.x - transform.position.x, trans.y - transform.position.y).normalized;
    }
    //Get variable of direction outside the script
    public Vector2 GetDirection()
    {
        return direction;
    }
    //Flip the sprite and everything inside of game object when switching velocity x
    public void FlipX()
    {
        if ((rb.velocity.x > 0f && rb.transform.localScale.x < 0f) || (rb.velocity.x < 0f && rb.transform.localScale.x > 0f))
            rb.transform.localScale = Vector3.Scale(rb.transform.localScale, new Vector3(-1f, 1f, 1f));
    }
    private void LateUpdate()
    {
        FlipX();
    }
}
