using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineCollision : MonoBehaviour
{
    private SpellManager spellManager;

    void Start()
    {
        spellManager = GetComponent<SpellManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            GameObject.Find("Player").GetComponent<SpellManager>().EarnMana(25);
            Destroy(collision.gameObject);
            
        }
    }

}
