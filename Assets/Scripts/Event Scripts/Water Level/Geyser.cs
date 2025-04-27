using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geyser : MonoBehaviour
{
    private bool inGeyser;

     void Start()
    {
        inGeyser = false;
    }


    void Update()
    {
        Propel();
    }

    public void Propel()
    {
        if (inGeyser)
        {
            GameObject.Find("Player").GetComponent<CharacterController>().Move(this.transform.up * .8f);
        }
        else
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inGeyser = true;
           

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inGeyser = false;
        }
    }


}
