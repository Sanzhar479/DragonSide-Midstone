using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJumping : MonoBehaviour
{

    public float fallMultiplier = 4.5f;
    public float lowJumpMultiplier = 1f;

 

    public void FallMultiplier(Rigidbody2D _rb, bool _ActivateGravity)
    {
        if (_ActivateGravity)
        {
            if (_rb.velocity.y < 0)
            {
                _rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
                _rb.gravityScale = fallMultiplier;
            }
            else if (_rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                //rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
                _rb.gravityScale = lowJumpMultiplier;
            }
           
        }
        else
        { _rb.gravityScale = 0f; }
    }
}
