using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;
using Color = System.Drawing.Color;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController characterController;
    private PlayerInputHandler inputHandler;
    private PlayerJumping jumping;


    private InputActionReference lookControl;

    private Animator animator;

    private float speed;
    public LayerMask groundMask;
    public Vector3 currentMovement = Vector3.zero;

    internal float walking = 40f;
    private float sprintMultiplier = 1.5f;

    private int rotationSpeed = 5;
    private Transform cameraMain;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        inputHandler = PlayerInputHandler.Instance;
        animator = GetComponent<Animator>();
        cameraMain = Camera.main.transform;
    }

    public void Movement()
    {
        if (GameObject.Find("PauseMenuUI").GetComponent<PauseMenu>().isPaused == false)
        {
            float speed = walking * (inputHandler.SprintValue > 0 ? sprintMultiplier : 1f);

            
            Vector3 horizontalMovement = new Vector3(inputHandler.MoveInput.x, 0f, inputHandler.MoveInput.y);
            horizontalMovement = cameraMain.transform.forward * horizontalMovement.z + cameraMain.transform.right * horizontalMovement.x;
            horizontalMovement.y = 0f;
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

            if (horizontalMovement != Vector3.zero)
            {
                Quaternion rotate = Quaternion.LookRotation(horizontalMovement, Vector3.up);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotate, Time.deltaTime * rotationSpeed);  
            }
         
        }
    }


    //Sends out raycast to detect if the player is touching the ground
    public bool IsGrounded()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out RaycastHit hit, 1f))
        {

            if (hit.collider != null)
            {
                GameObject.Find("Player").GetComponent<PlayerJumping>().canJump = false;
            }
            return true;
        }
        else
        {
            GameObject.Find("Player").GetComponent<PlayerJumping>().canJump = true;
            return false;
        }
    }

}


