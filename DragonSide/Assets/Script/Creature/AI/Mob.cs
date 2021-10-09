using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : Creture
{
    //target
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float acceleration;
    [SerializeField] private float velocity;
    //Both gain speed, slowly accelerating to target
    public IEnumerator AccelerateToPlayerX()
    {
        while (true)
        {
            SetDirectionTo(playerTransform.position);
            rb.AddForce(new Vector2(rb.mass * acceleration * GetDirection().x, 0.0f));
            yield return null;
        }
    }
    public IEnumerator AccelerateToPlayerY()
    {
        while (true)
        {
            SetDirectionTo(playerTransform.position);
            rb.AddForce(new Vector2(0.0f, rb.mass * acceleration * GetDirection().y));
            yield return null;
        }
    }
    //These ones set one stable velocity with which enemy is moving to target 
    public IEnumerator MoveToPlayerX()
    {
        while (true)
        {
            SetDirectionTo(playerTransform.position);
            rb.velocity = new Vector2(GetDirection().x * velocity, rb.velocity.y);
            yield return null;
        }
    }
    public IEnumerator MoveToPlayerY()
    {
        SetDirectionTo(playerTransform.position);
        rb.velocity = new Vector2(rb.velocity.x, GetDirection().y * velocity);
        yield return new WaitForFixedUpdate();
    }
    //When target is on vision switch corutine to chasing
    public void Notice(/*IEnumerator coroutine*/)
    {
        StartState(AccelerateToPlayerX());
    }

}
