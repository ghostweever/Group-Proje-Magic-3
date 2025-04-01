using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpellManager : MonoBehaviour
{

    public int whatSpellAmI;
    private CharacterController characterController;
    private bool isGrounded;
    void Start()
    {
        whatSpellAmI = 0;
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void WhichSpellToCast()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            if (whatSpellAmI == 0 && isGrounded == false)
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            isGrounded = true;


        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            isGrounded = false;


        }
    }
}
