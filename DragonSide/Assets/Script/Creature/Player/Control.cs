using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    public Vector2 dir;

    public bool inDialogue;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (inDialogue == false)
        {
            dir.x = Input.GetAxis("Horizontal");
            dir.y = Input.GetAxis("Vertical");
            rb.transform.position += new Vector3(dir.x * speed, dir.y * speed, 0.0f);
        }
        else { dir.x = dir.y = 0; }

        
    }
}
