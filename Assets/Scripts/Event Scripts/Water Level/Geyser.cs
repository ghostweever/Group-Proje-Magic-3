using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geyser : MonoBehaviour
{
    public Transform geyser;
    public float speed = .5f;
    private Vector3 velocity = Vector3.zero;
    private bool inGeyser;

     void Start()
    {
        inGeyser = false;
    }


    void Update()
    {
        if (inGeyser)
        {
            GameObject.Find("Player").GetComponent<CharacterController>().Move(Vector3.up * .5f);
            StartCoroutine(DisableGeyser());
        } else
        {

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Geyser")
        {
            inGeyser = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inGeyser = false;

    }

    private IEnumerator DisableGeyser()
    {
        yield return new WaitForSeconds(.5f);
        geyser.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(3);
        geyser.GetChild(0).gameObject.SetActive(true);
    }

}
