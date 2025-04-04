using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Dash : MonoBehaviour

    
{

    public float dashSpeed = 10f;
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


    // Update is called once per frame
    void Update()
    {
        
    }

    public void DashSpell()
    {
        
            playerMovement.walking = dashSpeed;
            InvokeRepeating("RepeatRun", 0.001f, .001f);
            StartCoroutine(DisableDash());         

    }

    void RepeatRun()
    {
        player.transform.Translate(Vector3.forward.normalized * Time.deltaTime * 10f);
    }

    private IEnumerator DisableDash()
    {
        yield return new WaitForSeconds(5f);
        playerMovement.walking = 5f;
        CancelInvoke();
        
    }






}
