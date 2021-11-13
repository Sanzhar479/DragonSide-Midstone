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
    private int destinationPointIndex = 0;

    private void Awake()
    {
        creature = GetComponent<Creture>();
        rb = GetComponent<Rigidbody2D>();
        creature.StartState(DoPatrol());
    }

    public IEnumerator DoPatrol()
    {
        //creature.SetDirectionTo(points[destinationPointIndex].transform.position);
        while (true)
        {
            if (IsOnPoint())
            {
                destinationPointIndex = (int)Mathf.Repeat(destinationPointIndex + 1, points.Length);
                //creature.SetDirectionTo(points[destinationPointIndex].transform.position);
            }
            creature.SetDirectionTo(points[destinationPointIndex].transform.position);
           // Debug.Log(creature.GetDirection());
            rb.velocity = new Vector2(creature.GetDirection().x * speed, creature.GetDirection().y * speed);
            yield return new WaitForFixedUpdate();
        }
    }

    private bool IsOnPoint()
    {
        var dist = (points[destinationPointIndex].position - transform.position).magnitude;
        var isOnSpot = dist <= treshold;
        return isOnSpot;
    }
}