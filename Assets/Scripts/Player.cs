using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] Vector3 jump;
    private int jumpAmount = 2;
    private int input;

    public Rigidbody rb;

    private bool isGrounded;

    void Start()
    {
        speed = 4f;
        jump = new Vector3(0f, 1.1f, 0f);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jumping();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded == true)
        {
            speed *= 1.5f;

        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 4f;
           
        }

    }

    void Jumping()
    {
        if (Input.GetButtonDown("Jump") && jumpAmount > 1)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            jumpAmount--;
        }

        if (isGrounded == true)
        {
            jumpAmount = 2;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Floor")
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
