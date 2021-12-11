using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trails : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    //private Vector3 position;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private FightController fc;
    private void Update()
    {
        if (fc.GetCol().onGround)
        {
            if (rb.velocity.x != 0)
            {
                if (!particles.isPlaying)
                    particles.Play();
            }
            //transform.position = player.position;
        }
        else
        {
            
            if (particles.isPlaying)
            {
                //position = transform.position;
                particles.Stop();
            }
            //transform.position = position;
        }
    }
}
