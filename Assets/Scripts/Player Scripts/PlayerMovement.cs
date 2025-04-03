using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Color = System.Drawing.Color;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController characterController;
    public bool isGrounded;
    private PlayerInputHandler inputHandler;

    [SerializeField] private float speed;
    public LayerMask groundMask;
    public Vector3 currentMovement = Vector3.zero;
    private float verticalRotation;

    private float mouseSensitivity = 2.0f;
    private float upDownRange = 80.0f;
    

    [SerializeField] private float jumpSpeed = 3.5f;
    [SerializeField] private float gravity = 4.5f;
    private bool canDoubleJump;
    private bool canJump;
    private int jumpAmount;

    private float walking = 5f;
    private float sprintMultiplier = 1.5f;

    public AudioClip jumpClip;
    public bool playJumpSound;



    void Start()
    {
        characterController = GetComponent<CharacterController>();
        inputHandler = PlayerInputHandler.Instance;
        jumpAmount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotation();
        IsGrounded();

    }

    void Movement()
    {
        float speed = walking * (inputHandler.SprintValue > 0 ? sprintMultiplier : 1f);

        Vector3 horizontalMovement = new Vector3(inputHandler.MoveInput.x, 0f, inputHandler.MoveInput.y);
        horizontalMovement = transform.forward * horizontalMovement.z + transform.right * horizontalMovement.x;
        horizontalMovement.Normalize();

        currentMovement.x = horizontalMovement.x * speed;
        currentMovement.z = horizontalMovement.z * speed;

        Jumping();

        characterController.Move(currentMovement * Time.deltaTime);
    }

    void Rotation()
    {
        float mouseXRotation = inputHandler.LookInput.x * mouseSensitivity;
        transform.Rotate(0, mouseXRotation, 0);

        verticalRotation -= inputHandler.LookInput.y * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);


    }

    //Sends out raycast to detect if the player is touching the ground
    public bool IsGrounded()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out RaycastHit hit, 1.5f))
        {
            

            return true;

        }
        else
        {
            

            return false;
        }
    }
    void Jumping()
    {
        if (IsGrounded() && currentMovement.y < 0)
        {
            currentMovement.y = 0f;
            canJump = true;
            playJumpSound = true;

        }



        if (inputHandler.JumpTriggered && canJump && IsGrounded())
        {

            if (playJumpSound)
            {
                AudioSource.PlayClipAtPoint(jumpClip, transform.position, 1f);
                playJumpSound = false;
            }

            canDoubleJump = true;
            Debug.Log(canDoubleJump);
            currentMovement.y = jumpSpeed;
            StartCoroutine(JumpDelay());

        }
 
            if (inputHandler.JumpTriggered && canDoubleJump)
            {
                

                if (playJumpSound)
                {
                    AudioSource.PlayClipAtPoint(jumpClip, transform.position, 1f);
                    playJumpSound = false;
                }

            
                currentMovement.y = jumpSpeed;
                StartCoroutine(JumpDelay());
            }
        


        currentMovement.y -= gravity * Time.deltaTime;

        }

    
    private IEnumerator JumpDelay()
    {
        yield return new WaitForSeconds(1f);
        
        canDoubleJump = false;
        
    }

}

