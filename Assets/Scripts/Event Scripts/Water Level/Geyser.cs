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
            GameObject.Find("Player").GetComponent<CharacterController>().Move(GameObject.FindWithTag("Geyser").transform.up * .5f);
        }
        else
        {

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Geyser")
        {
            inGeyser = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Geyser")
        {
            inGeyser = false;
        }
    }

    //private IEnumerator DisableGeyser()
    //{
    //    yield return new WaitForSeconds(.5f);
    //    geyser.GetChild(0).gameObject.SetActive(false);
    //    yield return new WaitForSeconds(3);
    //    geyser.GetChild(0).gameObject.SetActive(true);
    //}

}
