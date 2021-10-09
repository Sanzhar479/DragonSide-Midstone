using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool grounded;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
            grounded = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
            grounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
            grounded = false;
    }
    public bool isGrounded()
    {
        return grounded;
    }
}
