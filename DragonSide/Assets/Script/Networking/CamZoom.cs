using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CamZoom : MonoBehaviour
{
    private CinemachineVirtualCamera cam;
    [SerializeField] private GameObject player;
    private float originalY;
    [SerializeField] private float ratio;

    private void Awake()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        originalY = player.transform.position.y;
    }
    private void FixedUpdate()
    {
        cam.m_Lens.OrthographicSize = 5.0f + (player.transform.position.y - originalY) * ratio;
    }
}
