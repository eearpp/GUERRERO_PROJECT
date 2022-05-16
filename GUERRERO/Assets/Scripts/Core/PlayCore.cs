using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayCore : MonoBehaviourPunCallbacks
{
    public static PlayCore Instance;
    PhotonView view;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject spawnTarget1;
    [SerializeField] GameObject spawnTarget2;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        if (PhotonNetwork.IsMasterClient)
        {
            SpwanObj(spawnTarget1, playerPrefab);
        }
        else if (!PhotonNetwork.IsMasterClient)
        {
            SpwanObj(spawnTarget2, playerPrefab);
        }
        
    }

    public void SpwanObj(GameObject target , GameObject ObjPrefab)
    {
        GameObject myPlayer = PhotonNetwork.Instantiate(ObjPrefab.name, target.transform.position, Quaternion.identity);
    }
}
