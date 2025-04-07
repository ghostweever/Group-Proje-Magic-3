using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrystalManager : MonoBehaviour
{

    public int playerCrystalCount;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EarnCrystal(int amount)
    {
        playerCrystalCount += amount;
    }

    void WinCondition()
    {
        if(playerCrystalCount == 3)
        {
            //Put win screen load here
        }
    }

}
