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
        mana = maxMana;
    }

    void Update()
    {
        if(mana > maxMana)
        {
            mana = maxMana;
        }

        
    }

    private void FixedUpdate()
    {
        AutoRegain();
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

    public void AutoRegain()
    {
        if (mana <= 40)
        {
            StartCoroutine(ResetMana());
        }
        if (mana >= 40)
        {
            StopAllCoroutines();
        }


    }

 private IEnumerator ResetMana()
    {
        yield return new WaitForSeconds(10);
        mana++;
    }
}
