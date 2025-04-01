using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isGrounded;
    private SpellManager spellManager;

    void Start()
    {
        spellManager = GetComponent<SpellManager>();
    }

    // Update is called once per frame
    void Update()
    {
        spellManager.WhichSpellToCast();
    }    

}
