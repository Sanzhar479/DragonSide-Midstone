using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : Creture
{
    //target
    public Transform playerTransform;
    [SerializeField] private Grid grid;
    List<Vector3> pathVectorList = new List<Vector3>();
    private Pathfinding pathFinding;
    int currentPathIndex;
    //Both gain speed, slowly accelerating to target
    protected override void Awake()
    {
        base.Awake();
        pathFinding = new Pathfinding(grid);
    }
    public Vector2 AccelerateToPlayer(float acceleration)
    {
        SetDirectionTo(playerTransform.position);
        return new Vector2(rb.velocity.x + (acceleration * Time.deltaTime) * GetDirection().x, rb.velocity.y + (acceleration * Time.deltaTime) * GetDirection().y);
    }
    //These ones set one stable velocity with which enemy is moving to target 
    public Vector2 MoveToPlayer(float velocity)
    {
        SetDirectionTo(playerTransform.position);
        return GetDirection() * velocity;
    }
    //Mob moves faster when it's far and slows down when close
    public Vector2 Arrival(float velocity)
    {
        SetDirection(playerTransform.position - rb.transform.position);
        return GetDirection() * velocity;
    }
    // Mob keep on spacific distance from player
    public Vector2 Avoid(float velocity, float distance)
    {
        SetDirection(transform.position - playerTransform.position);
        var dist = (rb.transform.position - playerTransform.position).magnitude;
        if (dist <= distance)
        {
            var rate = 1.75f - dist / distance;
            return velocity * rate * new Vector2(GetDirection().x, GetDirection().y).normalized;
        }
        else return Vector2.zero;
    }
    public void SetTargetPosition()
    {
        currentPathIndex = 0;
        pathVectorList = pathFinding.FindPath(rb.transform.position, playerTransform.position);
        if (pathVectorList != null && pathVectorList.Count > 1)
        {
            pathVectorList.RemoveAt(0);
        }
        //draw the path line
        for (int i = 0; i < pathVectorList.Count - 1; i++)
        {
            Debug.DrawLine(new Vector2(pathVectorList[i].x, pathVectorList[i].y), new Vector2(pathVectorList[i + 1].x, pathVectorList[i + 1].y), Color.green, 1, false);
        }
    }
    public Vector2 PathFindingA(float velocity)
    {
        if (pathVectorList != null)
        {
            Vector3 targetPosition = pathVectorList[currentPathIndex];
            if (Vector3.Distance(rb.transform.position, targetPosition) > 1f)
            {
                SetDirection((targetPosition - rb.transform.position).normalized);
                float distanceBefore = Vector3.Distance(rb.transform.position, targetPosition);
                return GetDirection() * velocity;
            }
            else
            {
                currentPathIndex++;
                if (currentPathIndex >= pathVectorList.Count)
                {
                    pathVectorList = null;
                }
            }
        }
        return Vector2.zero;
    }
}
