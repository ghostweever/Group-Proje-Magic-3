using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private CharacterController characterController;
    public bool isGrounded = true;

    [SerializeField] private float speed;

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

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            isGrounded = true;


        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            isGrounded = false;


        }
    }

}
