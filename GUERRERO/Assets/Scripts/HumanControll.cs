using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HumanControll : MonoBehaviourPunCallbacks
{
     PhotonView view;
     float inputX;
     float inputZ;
     Vector3 v_Movement;   

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (view.IsMine)
        {
            inputX = Input.GetAxis("Horizontal");
            inputZ = Input.GetAxis("Vertical");

            if (inputX == 0 && inputZ == 0)
            {
                CharacterCore.Instance.characterData._animator.SetBool("isRunning", false);
            }
            else
            {
                CharacterCore.Instance.characterData._animator.SetBool("isRunning", true);
            }
        }        
    }

    private void FixedUpdate()
    {
        if (CharacterCore.Instance.characterData._controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //CharacterCore.Instance.TakeDamnge(CharacterCore.Instance.characterData.damage);
                v_Movement.y = CharacterCore.Instance.characterData.jumpForce;
            }
            else
            {
                v_Movement.y = 0f;
            }
        }
        else
        {
            v_Movement.y -= CharacterCore.Instance.characterData.gravity * Time.deltaTime;
        }

        v_Movement = new Vector3(inputX * CharacterCore.Instance.characterData.moveSpeed, v_Movement.y , inputZ * CharacterCore.Instance.characterData.moveSpeed);
        CharacterCore.Instance.characterData._controller.Move(v_Movement);

        if ((inputZ != 0 || inputX != 0))
        {
            Vector3 facing = new Vector3(v_Movement.x, 0, v_Movement.z);
            transform.rotation = Quaternion.LookRotation(facing);
        }
    }
}
