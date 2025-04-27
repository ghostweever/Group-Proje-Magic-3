using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{

    private CharacterController characterController;
    private PlayerMovement playerMovement;
    private PauseMenu pauseMenu;

    internal float jumpSpeed = 19f;
    internal float gravity = 28.81f;

    private Animator animator;

    public bool canJump;

    [Header("Audio")]
    public AudioClip jumpClip;
    public AudioClip jumpSFXClip;


    private void Start()
    {
        animator = GetComponent<Animator>();        
    }

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerMovement = GetComponent<PlayerMovement>();
        pauseMenu = GetComponent<PauseMenu>();

    }

    public void Jumping()
    {

        if (GameObject.Find("PauseMenuUI").GetComponent<PauseMenu>().isPaused == false)
        {
            if (playerMovement.IsGrounded() && playerMovement.currentMovement.y < 0)
            {
                playerMovement.currentMovement.y = -2;
                canJump = true;
            }
            else
            {
                playerMovement.currentMovement.y -= gravity * Time.deltaTime;
                canJump = false;
            }

            if ((Input.GetButtonDown("Jump") || Input.GetButtonDown("XboxJump")) && canJump)
            {

                animator.SetTrigger("Jump");
                
                StartCoroutine(JumpAnimator());
                AudioSource.PlayClipAtPoint(jumpClip, transform.position, .7f);
                AudioSource.PlayClipAtPoint(jumpSFXClip, transform.position, .7f);
                playerMovement.currentMovement.y += Mathf.Sqrt(jumpSpeed * 2 * gravity);
                playerMovement.currentMovement.y = jumpSpeed;
            }

            

            

        }

       

    }

    private IEnumerator JumpAnimator()
    {
        yield return new WaitForSeconds(.05f);
        animator.SetBool("Jump", false);
        canJump = false;


    }
}
