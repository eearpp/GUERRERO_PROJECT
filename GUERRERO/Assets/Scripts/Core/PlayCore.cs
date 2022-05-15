using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayCore : MonoBehaviourPunCallbacks
{
    public static PlayCore Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;        
    }

    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject spawnTarget;

    private void Start()
    {
        SpwanObj(spawnTarget, playerPrefab);
    }

    public void SpwanObj(GameObject target , GameObject ObjPrefab)
    {
        GameObject myPlayer = PhotonNetwork.Instantiate(ObjPrefab.name, target.transform.position, Quaternion.identity);
    }
}
