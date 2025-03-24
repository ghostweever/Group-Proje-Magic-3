using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{

    private CharacterController characterController;
    [SerializeField] private float jumpSpeed = 3.5f;
    [SerializeField] private float gravity = 4.5f;
    private bool canDoubleJump = true;
    private int jumpAmount = 2;
    private Vector3 moveDirection = Vector3.zero;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump") && canDoubleJump == true)
        {

            moveDirection.y = jumpSpeed;
            jumpAmount--;

            if (jumpAmount <= 0)
            {
                canDoubleJump = false;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);

        if (characterController.isGrounded)
        {
            canDoubleJump = true;
            jumpAmount = 2;
        }

    }
}
