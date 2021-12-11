using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ControlMultiplayer : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    public Vector2 dir;
    public PhotonView view;
    public bool inDialogue;
    private Cinemachine.CinemachineVirtualCamera Camera;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
        Camera = FindObjectOfType<Cinemachine.CinemachineVirtualCamera>();
        Camera.Follow.parent = gameObject.transform;
    }

    private void FixedUpdate()
    {
        if (view.IsMine)
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
}
