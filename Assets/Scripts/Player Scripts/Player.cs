using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    private SpellManager spellManager;
    private PlayerJumping jumping;
    private PlayerMovement playerMovement;
    private PlayerRotation rotation;
    private MenuButtons menuButtons;
    

    public GameObject player;

    void Start()
    {
        spellManager = GetComponent<SpellManager>();
        jumping = GetComponent<PlayerJumping>();
        playerMovement = GetComponent<PlayerMovement>();
        rotation = GetComponent<PlayerRotation>();
        menuButtons = GetComponent<MenuButtons>();
    }

    // Update is called once per frame
    void Update()
    {
        spellManager.WhichSpellToCast();
        spellManager.WhichSecondarySpellToCast();
        jumping.Jumping();
        playerMovement.Movement();
        rotation.Rotation();
        Void();
        

    }

    void Void()
    {            
        if(player.transform.position.y <= -50)
        GameObject.Find("Void").GetComponent<MenuButtons>().GameOver();
        
    }

}
