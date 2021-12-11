using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine2 : Mob
{
    public const int PATROL = 0;
    public const int NOTICE = 1;
    public const int ATTACK = 2;
    private int state;
    //private IEnumerator current;
    [SerializeField] private PointPatrol patrol;
    [SerializeField] private float maxDistFromPlayer;
    protected override void Awake()
    {
        base.Awake();
        state = PATROL;
    }
    public void AI()
    {
        if ((playerTransform.position - rb.transform.position).magnitude > maxDistFromPlayer)
        {
            SetState(0);
        }
        else
        {
            rb.velocity = Arrival(2f);
            rb.velocity = rb.velocity + Avoid(rb.velocity.magnitude, 10f);
        }
    }
    public void SetState(int i)
    {
        state = i;
    }
    private void Patrol()
    {
        patrol.DoPatrol();
    }
    private void ChangeState()
    {
        switch (state)
        {
            case PATROL:
                Patrol();
                break;
            case NOTICE:
                AI();
                break;
            default:
                break;
        }
    }
    private void FixedUpdate()
    {
        ChangeState();
    } 
    //public void StartState(IEnumerator coroutine)
    //{
    //    //when we change state, creature resets its velocity
    //    rb.velocity = Vector2.zero;
    //    // if there is corutine playing stop it
    //    if (current != null)
    //        StopCoroutine(current);
    //    //Set new corutine to current one
    //    current = coroutine;
    //    StartCoroutine(coroutine);
    //}
}
