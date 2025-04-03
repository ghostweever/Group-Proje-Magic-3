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
    public int[] manaUse = {10, 25, 10};
    public int playerMana;
    public AudioClip attackClip;
    void Start()
    {
        whatSpellAmI = 0;
        playerMana = 100;
        characterController = GetComponent<CharacterController>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void WhichSpellToCast()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AudioSource.PlayClipAtPoint(attackClip, transform.position, 1f);
            

            //Grass Attack Spell
            if (whatSpellAmI == 0 && playerMana >= manaUse[0])
            {
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
                GameObject.Find("Player").GetComponent<MakeWater>().WaterSpell();
                playerMana -= manaUse[1];
                Debug.Log(playerMana);
            }
            else if (whatSpellAmI == 1 && playerMana < manaUse[1])
            {
                Debug.Log("Need to recharge mana!");
            }
            //Fire Attack Spell
            else if (whatSpellAmI == 2 && playerMana > manaUse[2])
            {
                playerMana -= manaUse[2];
                Debug.Log(playerMana);
            }
            else if (whatSpellAmI == 2 && playerMana < manaUse[2])
            {
                Debug.Log("Need to recharge mana!");
            }
        }
        //Changes Primary Element
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            whatSpellAmI++;
            Debug.Log(whatSpellAmI);

            if (whatSpellAmI > 2)
            {
                whatSpellAmI = 0;
            }
        }
    }

    public void WhichSecondarySpellToCast()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            

            //Grass and Water Mobility Spell
            if (whatSecondarySpellAmI == 0)
            {
                
            }
            //Fire and Water Mobility Spell
            else if (whatSecondarySpellAmI == 1 && !playerMovement.isGrounded)
            {
                GameObject.Find("Player").GetComponent<MakeCloud>().CloudSpell();
            }
            //Fire and Grass Mobility Spell
            else if (whatSecondarySpellAmI == 2)
            {

            }
        }
        //Changes Secondary Element
        if (Input.GetKeyDown(KeyCode.R))
        {
            whatSecondarySpellAmI++;
            Debug.Log(whatSecondarySpellAmI);
            if (whatSecondarySpellAmI > 2)
            {
                whatSecondarySpellAmI = 0;
            }
        }
    }

}
