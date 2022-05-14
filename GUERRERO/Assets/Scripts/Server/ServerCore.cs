using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ServerCore : MonoBehaviourPunCallbacks
{
    public enum sceneName
    {
        Loading,
        Lobby,
        Play
    }

    public sceneName Lobby_SceneName;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        LoadScene(Lobby_SceneName.ToString());
    }

    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
