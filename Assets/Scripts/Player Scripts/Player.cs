using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDataPersistence
{   
    private SpellManager spellManager;
    private PlayerJumping jumping;
    private PlayerMovement playerMovement;
    private MenuButtons menuButtons;
    private Animator animator;

    public AudioClip playerDance;
    public GameObject player;

    void Awake()
    {
        
    }

    void Start()
    {
        spellManager = GetComponent<SpellManager>();
        jumping = GetComponent<PlayerJumping>();
        playerMovement = GetComponent<PlayerMovement>();
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

        if(Input.GetButtonDown("XboxTaunt") || Input.GetButtonDown("KeyboardTaunt"))
        {
            animator.SetTrigger("Win");
            AudioSource.PlayClipAtPoint(playerDance, transform.position);

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


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WeaponEnemy" && GameObject.Find("Player").GetComponent<PlayerLives>().isInvincible == false)
        {
            StartCoroutine(GameObject.Find("Player").GetComponent<PlayerLives>().Invincible());
            
            GameObject.Find("Player").GetComponent<PlayerLives>().Damage(1);
        }
        if(other.tag == "Enemy" && GameObject.Find("Player").GetComponent<PlayerLives>().isInvincible == false)
        {
            StartCoroutine(GameObject.Find("Player").GetComponent<PlayerLives>().Invincible());
            GameObject.Find("Player").GetComponent<PlayerLives>().Damage(1);
        }
    }

    private IEnumerator resetAnim()
    {
        yield return new WaitForSeconds(5);
        animator.ResetTrigger("Win");
    }

}
