using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Control : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    public Vector2 dir;
    PhotonView view;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
    }

    private void FixedUpdate()
    {
       
            dir.x = Input.GetAxis("Horizontal");
            dir.y = Input.GetAxis("Vertical");
            rb.transform.position += new Vector3(dir.x * speed, dir.y * speed, 0.0f);
     
     
    }
}
