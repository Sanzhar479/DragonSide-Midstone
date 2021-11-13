using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public float MinX, MaxX, MinY, MaxY;

    private void Start()
    {
        Vector2 RandomPosition = new Vector2(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY));
        PhotonNetwork.Instantiate(playerPrefab.name, RandomPosition,Quaternion.identity);
    }
    
}
