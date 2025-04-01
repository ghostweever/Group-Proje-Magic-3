using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpellManager : MonoBehaviour
{

    public int whatSpellAmI;
    private CharacterController characterController;
    public PlayerMovement playerMovement;
    void Start()
    {
        whatSpellAmI = 0;
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

            if (whatSpellAmI == 0 && !playerMovement.IsGrounded())
            {
                GameObject.Find("Player").GetComponent<MakeCloud>().CloudSpell();
            }
            else if (whatSpellAmI == 1)
            {
                GameObject.Find("Player").GetComponent<MakeWater>().WaterSpell();
            }
            else if (whatSpellAmI == 2)
            {
                GameObject.Find("Player").GetComponent<MakeVineWhip>().VineSpell();
            }

        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            whatSpellAmI++;

            if (whatSpellAmI > 2)
            {
                whatSpellAmI = 0;
            }
        }
    }

}
