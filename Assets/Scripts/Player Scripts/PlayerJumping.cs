using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{

    private CharacterController characterController;
    [SerializeField] private float jumpSpeed = 3.5f;
    [SerializeField] private float gravity = 4.5f;
    private PlayerMovement playerMovement;
   
    private Vector3 moveDirection = Vector3.zero;
    private PlayerInputHandler inputHandler;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerMovement = GetComponent<PlayerMovement>();
        inputHandler = PlayerInputHandler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
       

    }
}
