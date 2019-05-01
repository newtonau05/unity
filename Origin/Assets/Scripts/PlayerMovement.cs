using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerRigidbody;
    public float speed = 6f;
    Vector3 movement;
    Vector3 playerTurning = new Vector3(0, 0, 0);


    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");
        float h = CnInputManager.GetAxis("Horizontal");
        float v = CnInputManager.GetAxis("Vertical");
        if (h==0 && v == 0)
        {
        }
        else
        {
            Move(h, v);
            Turning(h, v);
        }
        
    }

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning(float h, float v)
    {
        playerTurning.x = h;
        playerTurning.z = v;
        Quaternion newRotation = Quaternion.LookRotation(playerTurning);
        playerRigidbody.MoveRotation(newRotation);

    }
}
