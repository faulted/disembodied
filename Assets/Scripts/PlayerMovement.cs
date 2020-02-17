using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float horizontalMove = 0f;
    private bool jump = false;
    private bool crouch = false;

    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;


    private void Update() {

        // Get input direction from the player
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("PlayerSpeed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool("IsPlayerJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
            crouch = true;
        else if (Input.GetButtonUp("Crouch"))
            crouch = false;
    }

    private void FixedUpdate() {
        // Move the player based on direction
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        // Set jump back to false after Move has been called
        jump = false;
    }

    public void OnLanding() {
        animator.SetBool("IsPlayerJumping", false);
    }
}
