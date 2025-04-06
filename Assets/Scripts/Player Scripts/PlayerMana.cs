using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    private int mana;

    void Start()
    {
        mana = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HowMuchManaUsage(int manaUse)
    {
        mana -= (mana - manaUse);

        if (manaUse > mana)
        {

        }
    }
}
