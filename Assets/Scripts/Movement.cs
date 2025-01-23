using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D characterController;
    private float userInputx;
    private bool userJumpInput;
    public float spdMultiplier;
    public Animator animator;
    public Rigidbody2D body;


    // Update is called once per frame
    void Update()
    {
        userInputx = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {         
            userJumpInput = true;
        }

        animator.SetBool("jump", userJumpInput);
        animator.SetFloat("playerSpd", body.velocity.magnitude);

    }

    void FixedUpdate()
    {
        
        characterController.Move(userInputx*spdMultiplier, false, userJumpInput);

        userJumpInput = false;
    }
}
