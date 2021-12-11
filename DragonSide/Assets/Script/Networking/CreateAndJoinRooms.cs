using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField inputCreate;
    public TMP_InputField inputJoin;
    [SerializeField] private string LevelName;
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(inputCreate.text);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(inputJoin.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(LevelName);
    }

    public  void OnSwitchScene(string sceneName)
    {
        LevelName = sceneName;
    }
    private void Update()
    {
        Debug.Log(LevelName);
    }
}
