using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ServerCore : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject loading_canvas;
    [SerializeField] GameObject lobby_canvas;

    [SerializeField] InputField createInput;
    [SerializeField] InputField joinInput;

    [SerializeField] Button connectButton;
    [SerializeField] Text status;
    public enum SceneName
    {
        Lobby,
        play
    }

    public SceneName PlayScene;

    void Start()
    {
        loading_canvas.SetActive(true);
        lobby_canvas.SetActive(false);
        //PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        loading_canvas.SetActive(false);
        lobby_canvas.SetActive(true);
    }

    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    //-----OnClick
    public void ClickCreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text , new Photon.Realtime.RoomOptions() { MaxPlayers = 2});
    }

    public void ClickJoinRoom()
    {        
        PhotonNetwork.JoinRoom(joinInput.text);        
    }

    public void ClickConnect()
    {
        GameObject buttText = connectButton.transform.GetChild(0).gameObject;
        Text connectText = buttText.GetComponent<Text>();
        connectText.text = "Connecting....";
        PhotonNetwork.ConnectUsingSettings();
    }
    //-----OnClick
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(PlayScene.ToString());
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        status.text = "FULL ROOM";
        base.OnJoinRoomFailed(returnCode, message);
    }
}
