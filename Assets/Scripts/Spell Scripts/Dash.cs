using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dash : MonoBehaviour
    
{
    [Header("Dash Variables")]
    public float dashSpeed = 30f;
    public float dashLength = 5f;
    public float dashCooldown = 1f;

    CharacterController characterController;
    private PlayerMovement playerMovement;

    public float dashTimer;
    public bool isDashing;
    public bool canDash;

    public GameObject player;


     void Start()
    {
        canDash = false;
        characterController = GetComponent<CharacterController>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void DashSpell()
    {
       StartCoroutine(EnableDash());              
    }

    void RepeatRun()
    {
        player.transform.Translate(Vector3.forward.normalized * Time.deltaTime * 10f);
    }

    //Coroutines to prevent player from dashing continiously
    private IEnumerator DisableDash()
    {
        yield return new WaitForSeconds(5f);
        playerMovement.walking = 20f;
        CancelInvoke();
        
    }

    private IEnumerator EnableDash()
    {
        yield return new WaitForSeconds(.7f);
        playerMovement.walking = dashSpeed;
        InvokeRepeating("RepeatRun", 0.001f, .001f);
        StartCoroutine(DisableDash());
    }



}
