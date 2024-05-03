using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementP2 : MonoBehaviour
{

    public Movement controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal P2") * runSpeed;

        if (Input.GetButtonDown("Jump P2"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch P2"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch P2"))
        {
            crouch = false;
        }

    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}