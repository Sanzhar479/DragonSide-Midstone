using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator anim;
    private Control rb;
    private SpriteRenderer sprite;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Control>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        //if (rb.dir.x != 0)
        //    anim.SetFloat("dirxLast", rb.dir.x);
        //if (rb.dir.y != 0)
        //    anim.SetFloat("diryLast", rb.dir.y);

        if (rb.dir.x != 0 || rb.dir.y != 0)
        {
            anim.SetBool("Moving", true);
            anim.SetFloat("dirxLast", rb.dir.x);
            anim.SetFloat("diryLast", rb.dir.y);
        }
        else if (rb.dir.x < 1.0f && rb.dir.x > -1.0f || rb.dir.y < 1.0f && rb.dir.y > -1.0f)
            anim.SetBool("Moving", false);
        if (rb.dir.x > 0 && sprite.flipX == true)
        {
            sprite.flipX = false;
        } else if (rb.dir.x < 0 && sprite.flipX == false)
        {
            sprite.flipX = true;
        }   
        anim.SetFloat("dirx", rb.dir.x);
        anim.SetFloat("diry", rb.dir.y);
    }
}
