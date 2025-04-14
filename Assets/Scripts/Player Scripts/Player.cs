using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDataPersistence
{   
    private SpellManager spellManager;
    private PlayerJumping jumping;
    private PlayerMovement playerMovement;
    private PlayerRotation rotation;
    private MenuButtons menuButtons;
    private Animator animator;
   
    public GameObject player;

    void Start()
    {
        spellManager = GetComponent<SpellManager>();
        jumping = GetComponent<PlayerJumping>();
        playerMovement = GetComponent<PlayerMovement>();
        rotation = GetComponent<PlayerRotation>();
        menuButtons = GetComponent<MenuButtons>();
        animator = GetComponent<Animator>();
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

        if (Input.GetKeyDown(KeyCode.L))
        {
            animator.SetTrigger("Death");
        } else if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("Win");
        }


    }

    public void LoadData(GameData data)
    {
        if (GameObject.Find("SceneHandler").GetComponent<SceneHandler>().sceneName == "Hub")
        {
            this.transform.position = data.hubPosition;
        }
        else if (GameObject.Find("SceneHandler").GetComponent<SceneHandler>().sceneName == "Forest Level")
        {
            this.transform.position = data.forestPosition;
        }
    }

    public void SaveData(GameData data)
    {
        if (GameObject.Find("SceneHandler").GetComponent<SceneHandler>().sceneName == "Hub")
        {
            data.hubPosition = this.transform.position;
        }
        else if (GameObject.Find("SceneHandler").GetComponent<SceneHandler>().sceneName == "Forest Level")
        {
            data.forestPosition = this.transform.position;
        }
    }

    //If player falls off and hits the void they will die
    void Void()
    {            
        if(player.transform.position.y <= -50)
        GameObject.Find("Void").GetComponent<InGameSettings>().Death();
        
    }

}
