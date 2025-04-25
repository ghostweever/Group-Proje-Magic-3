using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glide : MonoBehaviour
{
    private PlayerJumping playerJumping;
    private PlayerMovement playerMovement;
    private Animator animator;

    private void Start()
    {
        playerJumping = GetComponent<PlayerJumping>();
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (playerMovement.IsGrounded())
        {
            ResetGravity();
            animator.ResetTrigger("Glide");
            animator.SetTrigger("Idle");
        }
    }

    public void GlideSpell()
        {

            playerJumping.gravity = 2f;
            transform.GetChild(2).gameObject.SetActive(true);
            StartCoroutine(EndSpell());
        
        }

    public void ResetGravity()
    {
        playerJumping.gravity = 28f;
        transform.GetChild(2).gameObject.SetActive(false);
    }

    private IEnumerator EndSpell()
    {
  
            yield return new WaitForSeconds(6.5f);
            ResetGravity();
            

    }
}   