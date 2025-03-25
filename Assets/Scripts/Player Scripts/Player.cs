using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isGrounded;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && isGrounded == false)
        {
            GameObject.Find("Player").GetComponent<MakeCloud>().CloudSpell();

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Find("Player").GetComponent<MakeWater>().WaterSpell();

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject.Find("Player").GetComponent<MakeVineWhip>().VineSpell();
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
