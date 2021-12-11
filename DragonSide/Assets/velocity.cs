using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocity : MonoBehaviour
{
    private Rigidbody2D rb;
    //[Range(-1, 1)]
    //[SerializeField] private float vel;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = new Vector2(vel, 0);
        if (rb.velocity.x > 0) rb.transform.localScale = new Vector3(1, 1, 1);
        if (rb.velocity.x < 0) rb.transform.localScale = new Vector3(-1, 1, 1);
    }
}
