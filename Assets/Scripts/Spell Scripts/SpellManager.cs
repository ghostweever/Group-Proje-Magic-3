using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpellManager : MonoBehaviour
{

    private int whatSpellAmI;
    private int whatSecondarySpellAmI;

    private CharacterController characterController;
    private PlayerMovement playerMovement;
    private ChangeSpellImages changeSpellImages;
    private ManaBar manaBar;
    private PlayerMana playerMana;
    private Dash dash;

    private Animator animator;

    public int[] manaUse = { 10, 25 };

    public AudioClip attackClip;
    void Start()
    {
        whatSpellAmI = 0;
        whatSecondarySpellAmI = 0;

        characterController = GetComponent<CharacterController>();
        playerMovement = GetComponent<PlayerMovement>();
        changeSpellImages = GetComponent<ChangeSpellImages>();
        dash = GetComponent<Dash>();
        manaBar = GetComponent<ManaBar>();
        playerMana = GetComponent<PlayerMana>();

        playerMana.maxMana = 100;
        playerMana.mana = playerMana.maxMana;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        manaBar.SetMana(playerMana.mana);
    }

    public void WhichSpellToCast()
    {
        if (GameObject.Find("PauseMenuUI").GetComponent<PauseMenu>().isPaused == false)
        {

            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("XboxFire1"))
            {

                GameObject.Find("Player").GetComponent<PlayerMana>().LoseMana(manaUse[0]);

                //Grass Attack Spell
                if (whatSpellAmI == 0 && playerMana.mana > manaUse[0])
                {
                    animator.SetTrigger("Grass");
                    AudioSource.PlayClipAtPoint(attackClip, transform.position, 1f);
                    GameObject.Find("Player").GetComponent<MakeVineWhip>().VineSpell();
                    Debug.Log(playerMana.mana);
                }
                //Water Attack Spell
                if (whatSpellAmI == 1 && playerMana.mana > manaUse[0])
                {
                    animator.SetTrigger("Water");
                    AudioSource.PlayClipAtPoint(attackClip, transform.position, 1f);
                    GameObject.Find("Player").GetComponent<MakeWater>().WaterSpell();
                    Debug.Log(playerMana);
                }
                if (whatSpellAmI == 2 && playerMana.mana > manaUse[0])
                {
                    animator.SetTrigger("Fire");
                    AudioSource.PlayClipAtPoint(attackClip, transform.position, 1f);
                    GameObject.Find("Player").GetComponent<FireProjectile>().FireSpell();
                    Debug.Log(playerMana);
                }
                else if (playerMana.mana < manaUse[0])
                {
                    Debug.Log("Need to recharge mana!");
                }
            }

            //Changes Primary Element
            if (Input.GetButtonDown("Switch1") || Input.GetButtonDown("XboxLB"))
            {

                changeSpellImages.ChangePrimary();
                whatSpellAmI++;
                Debug.Log(whatSpellAmI);

                if (whatSpellAmI >= 3)
                {
                    whatSpellAmI = 0;
                }
            }
        }
    }

    public void WhichSecondarySpellToCast()
    {
        if (GameObject.Find("PauseMenuUI").GetComponent<PauseMenu>().isPaused == false) {   

            if (Input.GetButtonDown("Fire2") || Input.GetButtonDown("XboxFire2"))
            {


                //Grass and Water Mobility Spell
                if ((whatSecondarySpellAmI == 0 && whatSpellAmI == 0) || (whatSecondarySpellAmI == 2 && whatSpellAmI == 1))
                {
                    animator.SetTrigger("Glide");
                }
                //Fire and Water Mobility Spell
                else if (((whatSecondarySpellAmI == 1 && whatSpellAmI == 1) || (whatSecondarySpellAmI == 0 && whatSpellAmI == 2)) && !playerMovement.IsGrounded())
                {
                    animator.SetTrigger("Cloud");
                    Debug.Log("Y");
                    GameObject.Find("Player").GetComponent<MakeCloud>().CloudSpell();
                }
                //Fire and Grass Mobility Spell
                else if ((whatSecondarySpellAmI == 2 && whatSpellAmI == 2) || (whatSecondarySpellAmI == 1 && whatSpellAmI == 0))
                {
                    animator.SetTrigger("Dash");
                    dash.canDash = true;
                    Debug.Log("MEOW");
                    GameObject.Find("Player").GetComponent<Dash>().DashSpell();
                }
                //Grass and Grass Combo
                else if((whatSecondarySpellAmI == 2 && whatSpellAmI == 0))
                {
                    animator.SetTrigger("Grass");
                    GameObject.Find("Player").GetComponent<MakeVineWhip>().VineComboSpell();
                }
                //Water and Water Combo
                else if ((whatSecondarySpellAmI == 0 && whatSpellAmI == 1))
                {
                    animator.SetTrigger("Water");
                    GameObject.Find("Player").GetComponent<MakeWater>().WaterComboSpell();
                }
                //Fire and Fire Combo
                else if ((whatSecondarySpellAmI == 1 && whatSpellAmI == 2))
                {
                    animator.SetTrigger("Fire");
                    GameObject.Find("Player").GetComponent<FireProjectile>().FireComboSpell();
                }
            }
            //Changes Secondary Element
            if (Input.GetButtonDown("Switch2") || Input.GetButtonDown("XboxRB"))
            {
                changeSpellImages.ChangeSecondary();
                whatSecondarySpellAmI++;
                Debug.Log(whatSecondarySpellAmI);

                if (whatSecondarySpellAmI >= 3)
                {
                    whatSecondarySpellAmI = 0;
                }
            }
        }
    }

    

}
