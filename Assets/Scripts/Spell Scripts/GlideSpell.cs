using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glide : MonoBehaviour
{
    private PlayerJumping playerJumping;
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerJumping = GetComponent<PlayerJumping>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void GlideSpell()
        {

            playerJumping.gravity = 2f;
            StartCoroutine(EndSpell());
        
        }

    public void ResetGravity()
    {
        playerJumping.gravity = 6f;
    }

    private IEnumerator EndSpell()
    {
  
            yield return new WaitForSeconds(6.5f);
            playerJumping.gravity = 6f;
        
    }
}
    


    
    