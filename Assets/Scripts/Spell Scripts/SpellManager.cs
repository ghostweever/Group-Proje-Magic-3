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

    private Dash dash;
    public int[] manaUse = {10, 25, 10};
    public int maxMana;
    public int playerMana;
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

        maxMana = 100;
        playerMana = maxMana;
    }

    void Update()
    {
        manaBar.SetMana(playerMana);
    }

    public void WhichSpellToCast()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("XboxFire1"))
        {

            

            //Grass Attack Spell
            if (whatSpellAmI == 0 && playerMana >= manaUse[0])
            {
                AudioSource.PlayClipAtPoint(attackClip, transform.position, 1f);
                GameObject.Find("Player").GetComponent<MakeVineWhip>().VineSpell();
                playerMana -= manaUse[0];
                Debug.Log(playerMana);
            } else if (whatSpellAmI == 0 && (playerMana < manaUse[0]))
            {
                Debug.Log("Need to recharge mana!");
            }
            //Water Attack Spell
            if (whatSpellAmI == 1 && playerMana >= manaUse[1])
            {
                AudioSource.PlayClipAtPoint(attackClip, transform.position, 1f);
                GameObject.Find("Player").GetComponent<MakeWater>().WaterSpell();
                playerMana -= manaUse[1];
                Debug.Log(playerMana);
            }
            else if (whatSpellAmI == 1 && playerMana < manaUse[1])
            {
                Debug.Log("Need to recharge mana!");
            }
            //Fire Attack Spell
            if (whatSpellAmI == 2 && playerMana > manaUse[2])
            {
                AudioSource.PlayClipAtPoint(attackClip, transform.position, 1f);
                GameObject.Find("Player").GetComponent<FireProjectile>().FireSpell();
                playerMana -= manaUse[2];
                Debug.Log(playerMana);
            }
            else if (whatSpellAmI == 2 && playerMana < manaUse[2])
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

            if (whatSecondarySpellAmI == whatSpellAmI)
            {
                whatSpellAmI++;
            }

            if (whatSpellAmI >= 3)
            {
                whatSpellAmI = 0;
            }
        }
    }

    public void WhichSecondarySpellToCast()
    {

        if (Input.GetButtonDown("Fire2") || Input.GetButtonDown("XboxFire2"))
        {
            

            //Grass and Water Mobility Spell
            if (whatSecondarySpellAmI == 0)
            {
                
            }
            //Fire and Water Mobility Spell
            else if (whatSecondarySpellAmI == 1 && !playerMovement.IsGrounded())
            {
                Debug.Log("Y");
                GameObject.Find("Player").GetComponent<MakeCloud>().CloudSpell();
            }
            //Fire and Grass Mobility Spell
            else if (whatSecondarySpellAmI == 2)
            {
                dash.canDash = true;
                Debug.Log("MEOW");
                GameObject.Find("Player").GetComponent<Dash>().DashSpell();
            }
        }
        //Changes Secondary Element
        if (Input.GetButtonDown("Switch2") || Input.GetButtonDown("XboxRB"))
        {
            changeSpellImages.ChangeSecondary();
            whatSecondarySpellAmI++;
            Debug.Log(whatSecondarySpellAmI);

            if(whatSecondarySpellAmI == whatSpellAmI)
            {
                whatSecondarySpellAmI++;
            }

            if (whatSecondarySpellAmI >= 3)
            {
                whatSecondarySpellAmI = 0;
            }
        }
    }

    public void EarnMana(int manaAmount)
    {
        playerMana += manaAmount;
        manaBar.SetMana(playerMana);
    }

}
