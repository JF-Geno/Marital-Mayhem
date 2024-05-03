using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementP1 : MonoBehaviour
{

    public Movement controller;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal P1") * runSpeed;

        if (Input.GetButtonDown("Jump P1"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch P1"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch P1"))
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