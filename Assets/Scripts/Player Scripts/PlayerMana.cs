using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public int mana;
    private ManaBar manaBar;
    public int maxMana;

    private void Start()
    {
        manaBar = GetComponent<ManaBar>();
        maxMana = 100;
    }

    void Update()
    {
        if(mana > maxMana)
        {
            mana = maxMana;
        }
    }

    //Adds and subtracts mana depending on what calls it
    public void EarnMana(int manaAmount)
    {
        mana += manaAmount;
        manaBar.SetMana(mana);
    }

    public void LoseMana(int manaAmount)
    {
        mana -= manaAmount;
        manaBar.SetMana(mana);
    }
}
