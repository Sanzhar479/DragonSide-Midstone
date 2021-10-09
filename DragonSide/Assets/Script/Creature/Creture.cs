using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creture : MonoBehaviour
{
    private Vector2 direction = new Vector2(0.0f, 0.0f);
    //Current corutine and state of the mob
    private IEnumerator current;
    protected Rigidbody2D rb;
    private void Awake()
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
        direction = new Vector2(trans.x - transform.position.x > 0? 1 : -1, trans.y - transform.position.y > 0 ? 1 : -1);
    }
    //Get variable of direction outside the script
    public Vector2 GetDirection()
    {
        return direction;
    }
    //Flip the sprite and everything inside of game object when switching velocity x
    public void FlipX()
    {
        if (rb.velocity.x > 0)
        {
            rb.transform.localScale = new Vector2(Mathf.Abs(rb.transform.localScale.x), rb.transform.localScale.y);
        }
        if (rb.velocity.x < 0)
        {
            //we get local scale and make it negetive
            var flip = -Mathf.Abs(rb.transform.localScale.x);
            Debug.Log(flip);
            rb.transform.localScale = new Vector2(flip, rb.transform.localScale.y);
        }
    }
    //Creature can have only one corutine playing
    //Here we switch from current corutine to another
    public void StartState(IEnumerator coroutine)
    {
        //when we change state, creature resets its velocity
        rb.velocity = Vector2.zero;
        // if there is corutine playing stop it
        if (current != null)
            StopCoroutine(current);
        //Set new corutine to current one
        current = coroutine;
        StartCoroutine(coroutine);
    }
    private void Update()
    {
        FlipX();
    }
}
