using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanControll : MonoBehaviour
{
    CharacterController _controller;
    Animator _animator;

     float inputX;
     float inputZ;
     Vector3 v_Movement;
    public float movespeed;
    public float jumpforce;
    public float gravity;

    private void Start()
    {

        GameObject tempPlayer = this.gameObject;
        _controller = tempPlayer.GetComponent<CharacterController>();
        _animator = tempPlayer.GetComponent<Animator>();
    }

    private void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        if (inputX == 0 && inputZ == 0)
        {
            _animator.SetBool("isRunning", false);
        }
        else
        {
            _animator.SetBool("isRunning", true);
        }
    }

    private void FixedUpdate()
    {
        if (_controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                v_Movement.y = jumpforce;
            }
            else
            {
                v_Movement.y = 0f;
            }
        }
        else
        {
            v_Movement.y -= gravity * Time.deltaTime;
        }

        v_Movement = new Vector3(inputX * movespeed, v_Movement.y , inputZ * movespeed);
        _controller.Move(v_Movement);

        if ((inputZ != 0 || inputX != 0))
        {
            Vector3 facing = new Vector3(v_Movement.x, 0, v_Movement.z);
            transform.rotation = Quaternion.LookRotation(facing);
        }
    }
}
