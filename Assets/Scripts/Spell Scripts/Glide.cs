using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glide : MonoBehaviour
{
   private PlayerMovement playerMovement;
   private Player Jumping playerJumping;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {


            if (playerMovement.IsGrounded() == false)
            {
                while (playerMovement.IsGrounded() == false)
                {
                    playerJumping.gravity = 1.5f;

                     

                }
            } 
            if (playerMovement.IsGrounded() == true)
             {
                    playerJumping.gravity = 4.5f;

             }
            

        }

    }
}
