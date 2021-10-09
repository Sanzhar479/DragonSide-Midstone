using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private float treshold = 0f;
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    private Creture creature;
    private int destinationPointIndex;

    private void Awake()
    {
        creature = GetComponent<Creture>();
        rb = GetComponent<Rigidbody2D>();
        creature.StartState(DoPatrol());
    }

    public IEnumerator DoPatrol()
    {
        while (true)
        {
            if (IsOnPoint())
            {
                destinationPointIndex = (int)Mathf.Repeat(destinationPointIndex + 1, points.Length);
            }

            creature.SetDirectionTo(points[destinationPointIndex].transform.position);
            rb.velocity = new Vector2(creature.GetDirection().x * speed, rb.velocity.y);

            yield return null;
        }
    }

    private bool IsOnPoint()
    {
        var isOnSpot = (points[destinationPointIndex].position - transform.position).magnitude <= treshold;
        return isOnSpot;
    }
}