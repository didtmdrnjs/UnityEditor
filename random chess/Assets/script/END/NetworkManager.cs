using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun.Demo.Cockpit;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    private int RoomCount;

    public void ClickButton()
    {
        Screen.SetResolution(1920, 1080, true);
        PhotonNetwork.ConnectUsingSettings();
        RoomCount = 0;
    }

    public override void OnConnectedToMaster() => PhotonNetwork.JoinRandomRoom();

    public override void OnDisconnected(DisconnectCause cause)
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom("Normal" + RoomCount, new RoomOptions { MaxPlayers = 2 });
        RoomCount++;
    }

    private void Update()
    {
        if (PhotonNetwork.InRoom && PhotonNetwork.CurrentRoom.Players.Count == 2)
        {
            SceneManager.LoadScene("NormalOnLine");
        }
    }

    public void Awake()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
        }
    }
}
