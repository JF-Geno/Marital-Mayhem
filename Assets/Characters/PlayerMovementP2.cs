using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementP2 : MonoBehaviour
{

    public Movement controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {

        
        if (!P1Health.isInputDisabled)
        {

            horizontalMove = Input.GetAxisRaw("Horizontal P2") * runSpeed;

            animator.SetFloat("Speed",  Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump P2"))
            {
                jump = true;
                animator.SetBool("IsJumping",  true);
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
       

    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}