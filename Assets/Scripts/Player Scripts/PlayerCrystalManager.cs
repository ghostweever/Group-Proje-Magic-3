using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCrystalManager : MonoBehaviour
{

    public int playerCrystalCount;
    public bool winCon = true;
    private int crystalsNeeded;

    void Start()
    {
        playerCrystalCount = 3;
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


    
    
}
