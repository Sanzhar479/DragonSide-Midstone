using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : Creture
{
    //target
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Grid grid;
    private Pathfinding pathFinding;
    //Both gain speed, slowly accelerating to target
    private void Start()
    {
        pathFinding = grid.GetMap();
    }
    public Vector2 AccelerateToPlayer(float acceleration)
    {
        SetDirectionTo(playerTransform.position);
        return new Vector2(rb.velocity.x + acceleration * Time.deltaTime, rb.velocity.y + acceleration * Time.deltaTime);
    }
    //These ones set one stable velocity with which enemy is moving to target 
    public Vector2 MoveToPlayer(float velocity)
    {
            SetDirectionTo(playerTransform.position);
            return GetDirection() * velocity;
    }
    //Mob moves faster when it's far and slows down when close
    //Also Mob keep on spacific distance from player
    public Vector2 Arrival(float velocity)
    {
            SetDirection(playerTransform.position - rb.transform.position);
            return GetDirection() * velocity;
    }
    public Vector2 Avoid(float velocity, float distance)
    {
        SetDirectionTo(-playerTransform.position);
        var dist = (rb.transform.position - playerTransform.position).magnitude;
        if (dist <= distance)
            return -velocity * new Vector2(GetDirection().x, GetDirection().y).normalized;
        else return Vector2.zero;
    }

    public Vector2 SetPathFindingA(float velocity)
    {
        List<Vector2> pathVectorList = pathFinding.FindPath(rb.transform.position, playerTransform.position);
        Debug.Log(pathVectorList.Count);
        if (pathVectorList != null && pathVectorList.Count > 1)
        {
            pathVectorList.RemoveAt(0);
        }
        SetDirectionTo(pathVectorList[0]);
        return GetDirection() * velocity;
    }
    protected IEnumerator AI(Vector2 ai_)
    {
        while (true)
        {
            rb.velocity = ai_;
            yield return null;
        }
    }
    protected IEnumerator AI(Vector2 ai_, Vector2 ai1_)
    {
        while (true)
        {
            rb.velocity = ai_ + ai1_;
            yield return null;
        }
    }
    protected IEnumerator AI(Vector2 ai_, Vector2 ai1_, Vector2 ai2_)
    {
        while (true)
        {
            rb.velocity = ai_ + ai1_ + ai2_;
            yield return null;
        }
    }
}
