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
    }

    void Update()
    {
        manaBar.SetMana(playerMana.mana);
    }

    public void WhichSpellToCast()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("XboxFire1"))
        {

            GameObject.Find("Player").GetComponent<PlayerMana>().LoseMana(manaUse[0]);

            //Grass Attack Spell
            if (whatSpellAmI == 0 && playerMana.mana > manaUse[0])
            {
                AudioSource.PlayClipAtPoint(attackClip, transform.position, 1f);
                GameObject.Find("Player").GetComponent<MakeVineWhip>().VineSpell();
                Debug.Log(playerMana.mana);
            }
            //Water Attack Spell
            if (whatSpellAmI == 1 && playerMana.mana > manaUse[0])
            {
                AudioSource.PlayClipAtPoint(attackClip, transform.position, 1f);
                GameObject.Find("Player").GetComponent<MakeWater>().WaterSpell();
                Debug.Log(playerMana);
            }
            if (whatSpellAmI == 2 && playerMana.mana > manaUse[0])
            {
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

            if (whatSecondarySpellAmI >= 3)
            {
                whatSecondarySpellAmI = 0;
            }
        }
    }

    

}
