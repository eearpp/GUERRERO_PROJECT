using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;
    public float smoothSpeed;
    public Vector3 offset;
    private bool locked = false ;

    void Start()
    {
        GameObject tempplayer = GameObject.FindGameObjectWithTag("Player");
        target = tempplayer.GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            if(locked == false)
            {
                locked = true;
            }
            else if(locked == true)
            {
                locked = false;
            }
            Debug.Log(locked);
        }
    }

    void FixedUpdate()
    {          
        if(locked == false)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
            transform.LookAt(target);
        }        
    }
    
}
