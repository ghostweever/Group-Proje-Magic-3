using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{

    private CharacterController characterController;
    private PlayerMovement playerMovement;
    private PauseMenu pauseMenu;

    [SerializeField] private float jumpSpeed = 3.5f;
    [SerializeField] private float gravity = 4.5f;
    
    private bool canJump;
    private int jumpAmount;
    public AudioClip jumpClip;


    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerMovement = GetComponent<PlayerMovement>();
        pauseMenu = GetComponent<PauseMenu>();
        jumpAmount = 2;

    }

    public void Jumping()
    {

        if (GameObject.Find("PauseMenuUI").GetComponent<PauseMenu>().isPaused == false)
        {
            if (playerMovement.IsGrounded() && playerMovement.currentMovement.y < 0)
            {
                playerMovement.currentMovement.y = 0f;
                canJump = true;
                jumpAmount = 2;
            }

            if ((Input.GetButtonDown("Jump") || Input.GetButtonDown("XboxJump")) && canJump)
            {
                AudioSource.PlayClipAtPoint(jumpClip, transform.position, .7f);
                playerMovement.currentMovement.y += Mathf.Sqrt(jumpSpeed * 2 * gravity);
                playerMovement.currentMovement.y = jumpSpeed;
                jumpAmount--;
                Debug.Log(jumpAmount);


                if (jumpAmount <= 0)
                {
                    canJump = false;
                }

            }

            playerMovement.currentMovement.y -= gravity * Time.deltaTime;

        }
    }
}
