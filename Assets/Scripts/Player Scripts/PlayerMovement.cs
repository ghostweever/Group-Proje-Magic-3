using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using Color = System.Drawing.Color;

public class PlayerMovement : MonoBehaviour
{
    
    private CharacterController characterController;
    public bool isGrounded;

    [SerializeField] private float speed;
    public LayerMask groundMask;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        characterController.Move(move * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded == true)
        {
            Debug.Log("hi");
            speed *= 1.5f;

        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 4f;

        }

        IsGrounded();

    }

    public bool IsGrounded()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out RaycastHit hit, 1.5f))
        {
            Debug.Log("Hit");
            
            return true;
            
        } else
        {
            Debug.Log("Nope");
            
            return false;
        }
    }
    
}
