using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour

    
{

    public float dashSpeed = 10f;
    public float dashLength = 5f;
    public float dashCooldown = 1f;

    private float dashTimer;
    private bool isDashing;
    private bool canDash = true;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && canDash)
        {
            isDashing = true;
            canDash = false;
            dashTimer = 0f;
        }

        if (isDashing)
        {
            // Move the character during the dash
            CharacterController characterController = GetComponent<CharacterController>();
            if (characterController != null)
            {
                characterController.Move(transform.forward * dashSpeed * Time.deltaTime);
            }
            dashTimer += Time.deltaTime;
            if (dashTimer >= dashLength)
            {
                isDashing = false;
                dashTimer = 0f;
                Invoke("ResetDash", dashCooldown);
            }
        }
    }

    void ResetDash()
    {
        canDash = true;
    }






}
