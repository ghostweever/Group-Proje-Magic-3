using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrystalManager : MonoBehaviour
{

    public int playerCrystalCount;
    public bool winCon = true;
    private int crystalsNeeded;

    void Start()
    {
        playerCrystalCount = 0;
        crystalsNeeded = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EarnCrystal(int amount)
    {
        playerCrystalCount += amount;
    }



    public bool WinCondition()
    {
        if(playerCrystalCount == crystalsNeeded)
        {
            return true;
            
        } else
        {
            return false;
        }
    }

}
