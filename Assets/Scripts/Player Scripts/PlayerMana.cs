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

    }

    void Update()
    {
        
    }

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
