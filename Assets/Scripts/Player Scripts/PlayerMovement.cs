using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

using Color = System.Drawing.Color;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController characterController;
    private PlayerInputHandler inputHandler;
    private PlayerJumping jumping;

    private Animator animator;

    private float speed;
    public LayerMask groundMask;
    public Vector3 currentMovement = Vector3.zero;

    public float walking = 5f;
    private float sprintMultiplier = 1.5f;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        inputHandler = PlayerInputHandler.Instance;
        animator = GetComponent<Animator>();
        
    }

   public void Movement()
    {
        if (GameObject.Find("PauseMenuUI").GetComponent<PauseMenu>().isPaused == false)
        {
            float speed = walking * (inputHandler.SprintValue > 0 ? sprintMultiplier : 1f);

            Vector3 horizontalMovement = new Vector3(inputHandler.MoveInput.x, 0f, inputHandler.MoveInput.y);
            horizontalMovement = transform.forward * horizontalMovement.z + transform.right * horizontalMovement.x;
            horizontalMovement.Normalize();

            currentMovement.x = horizontalMovement.x * speed;
            currentMovement.z = horizontalMovement.z * speed;

            if (horizontalMovement == Vector3.zero)
            {
                animator.SetFloat("Speed", 0);
            }
            else if (speed > walking)
            {
                animator.SetFloat("Speed", 1f);
            }
            else
            {
                animator.SetFloat("Speed", .011f);
            }

            characterController.Move(currentMovement * Time.deltaTime);


        }
    }

    //Sends out raycast to detect if the player is touching the ground
    public bool IsGrounded()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out RaycastHit hit, 1f))
        {
            Debug.Log("hit");

            return true;

        }
        else
        {
            Debug.Log("no");

            return false;
        }
    }

}

