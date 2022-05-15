using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CharacterCore : MonoBehaviourPunCallbacks
{
    [System.Serializable]
    public class CharacterData
    {
        public CharacterController _controller;
        public Animator _animator;

        public float moveSpeed;
        public float jumpForce;
        public float gravity;

        public float health;
        public float damage;
        public float armor;
        public int coin;
    }
    
    //-------Singleton
    PhotonView view;
    public static CharacterCore Instance;    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    //-------Singleton

    public CharacterData characterData;

    void Start()
    {
        view = GetComponent<PhotonView>();
        if (!characterData._controller || !characterData._animator)
        {
            GameObject tempPlayer = this.gameObject;
            characterData._controller = tempPlayer.GetComponent<CharacterController>();
            characterData._animator = tempPlayer.GetComponent<Animator>();
        }
    }

    void Update()
    {
        
    }

    public void TakeDamnge(float damange)
    {
        if (view.IsMine)
        {
            characterData.health = characterData.health - damange;
        }        
    }
}
