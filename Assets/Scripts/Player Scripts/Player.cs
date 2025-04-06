using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    private SpellManager spellManager;
    private PlayerJumping jumping;
    private PlayerMovement playerMovement;
    private PlayerRotation rotation;

    public GameObject player;

    void Start()
    {
        spellManager = GetComponent<SpellManager>();
        jumping = GetComponent<PlayerJumping>();
        playerMovement = GetComponent<PlayerMovement>();
        rotation = GetComponent<PlayerRotation>();
    }

    // Update is called once per frame
    void Update()
    {
        spellManager.WhichSpellToCast();
        spellManager.WhichSecondarySpellToCast();
        jumping.Jumping();
        playerMovement.Movement();
        rotation.Rotation();

    }    

}
