using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private bool spellInUse = false;

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
        //Updates mana bar constantly
        manaBar.SetMana(playerMana.mana);
    }

    public void WhichSpellToCast()
        //Finds which spell to cast based on their spell value
    {
        if (GameObject.Find("PauseMenuUI").GetComponent<PauseMenu>().isPaused == false)
        {

            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("XboxFire1"))
            {
                //If player is above mana requirement and a spell isnt in use they can cast a spell
                if (playerMana.mana > manaUse[0] && !spellInUse) {

                    

                    //Grass Attack Spell
                    if (whatSpellAmI == 0)
                    {
                        spellInUse = true;
                        StartCoroutine(ComboSpellCooldown());
                        animator.SetTrigger("Grass");
                        AudioSource.PlayClipAtPoint(attackClip, transform.position, 1f);
                        GameObject.Find("Player").GetComponent<MakeVineWhip>().VineSpell();
                        GameObject.Find("Player").GetComponent<PlayerMana>().LoseMana(manaUse[0]);
                        Debug.Log(playerMana.mana);
                    }
                    //Water Attack Spell
                    if (whatSpellAmI == 1)
                    {
                        spellInUse = true;
                        StartCoroutine(ComboSpellCooldown());
                        animator.SetTrigger("Water");
                        AudioSource.PlayClipAtPoint(attackClip, transform.position, 1f);
                        GameObject.Find("Player").GetComponent<MakeWater>().WaterSpell();
                        GameObject.Find("Player").GetComponent<PlayerMana>().LoseMana(manaUse[0]);
                        Debug.Log(playerMana);
                    }
                    //Fire Attack
                    if (whatSpellAmI == 2)
                    {
                        spellInUse = true;
                        StartCoroutine(ComboSpellCooldown());
                        animator.SetTrigger("Fire");
                        AudioSource.PlayClipAtPoint(attackClip, transform.position, 1f);
                        GameObject.Find("Player").GetComponent<FireProjectile>().FireSpell();
                        GameObject.Find("Player").GetComponent<PlayerMana>().LoseMana(manaUse[0]);
                        Debug.Log(playerMana);
                    }
                }
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
    
    public void WhichSecondarySpellToCast()
    {
        //Finds which spell to cast based on their spell value, it fetches the primary spell value to  determine which spell can be casted

        if (GameObject.Find("PauseMenuUI").GetComponent<PauseMenu>().isPaused == false) {

            if ((Input.GetButtonDown("Fire2") || Input.GetButtonDown("XboxFire2")) && !spellInUse)
            {
                if (playerMana.mana > manaUse[1])
                {

                    //Grass and Water Mobility Spell
                    if (((whatSecondarySpellAmI == 0 && whatSpellAmI == 0) || (whatSecondarySpellAmI == 2 && whatSpellAmI == 1)) && !playerMovement.IsGrounded())
                    {
                        animator.ResetTrigger("Idle");
                        animator.SetTrigger("Glide");
                        GameObject.Find("Player").GetComponent<Glide>().GlideSpell();
                        GameObject.Find("Player").GetComponent<PlayerMana>().LoseMana(manaUse[1]);
                        spellInUse = true;
                        StartCoroutine(GlideSpellCooldown());

                        
                    }
                    //Fire and Water Mobility Spell
                    else if (((whatSecondarySpellAmI == 1 && whatSpellAmI == 1) || (whatSecondarySpellAmI == 0 && whatSpellAmI == 2)) && (!playerMovement.IsGrounded()))
                    {
                        animator.SetTrigger("Cloud");
                        GameObject.Find("Player").GetComponent<MakeCloud>().CloudSpell();
                        GameObject.Find("Player").GetComponent<PlayerMana>().LoseMana(manaUse[1]);
                        spellInUse = true;
                        StartCoroutine(ComboSpellCooldown());

                    }
                    //Fire and Grass Mobility Spell
                    else if ((whatSecondarySpellAmI == 2 && whatSpellAmI == 2) || (whatSecondarySpellAmI == 1 && whatSpellAmI == 0))
                    {
                        animator.SetTrigger("Dash");
                        dash.canDash = true;
                        GameObject.Find("Player").GetComponent<Dash>().DashSpell();
                        GameObject.Find("Player").GetComponent<PlayerMana>().LoseMana(manaUse[1]);
                        spellInUse = true;
                        StartCoroutine(GlideSpellCooldown());

                    }
                    //Grass and Grass Combo
                    else if ((whatSecondarySpellAmI == 2 && whatSpellAmI == 0))
                    {
                        animator.SetTrigger("Grass");
                        GameObject.Find("Player").GetComponent<MakeVineWhip>().VineComboSpell();
                        GameObject.Find("Player").GetComponent<PlayerMana>().LoseMana(manaUse[1]);
                        spellInUse = true;
                        StartCoroutine(ComboSpellCooldown());

                    }
                    //Water and Water Combo
                    else if ((whatSecondarySpellAmI == 0 && whatSpellAmI == 1))
                    {
                        animator.SetTrigger("Water");
                        GameObject.Find("Player").GetComponent<MakeWater>().WaterComboSpell();
                        GameObject.Find("Player").GetComponent<PlayerMana>().LoseMana(manaUse[1]);
                        spellInUse = true;
                        StartCoroutine(ComboSpellCooldown());

                    }
                    //Fire and Fire Combo
                    else if ((whatSecondarySpellAmI == 1 && whatSpellAmI == 2))
                    {
                        animator.SetTrigger("Fire");
                        GameObject.Find("Player").GetComponent<FireProjectile>().FireComboSpell();
                        GameObject.Find("Player").GetComponent<PlayerMana>().LoseMana(manaUse[1]);
                        spellInUse = true;
                        StartCoroutine(ComboSpellCooldown());

                    }
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

    //different cooldown for longer spells
    private IEnumerator GlideSpellCooldown()
    {

        yield return new WaitForSeconds(7f);
        spellInUse = false;

    }
         
    private IEnumerator ComboSpellCooldown()
    {
        yield return new WaitForSeconds(.5f);
        spellInUse = false;
    }

}
