using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCrystalManager : MonoBehaviour
{

    public int playerCrystalCount;
    public bool winCon = true;
    private int crystalsNeeded;
    public int playerCrystalInHand;

    void Start()
    {
        
        crystalsNeeded = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveCrystal()
    {
        PlayerPrefs.SetInt("PlayerCrystal", playerCrystalCount);
    }

    public void LoadCrystal()
    {
        playerCrystalCount = PlayerPrefs.GetInt("PlayerCrystal");
    }

    public void EarnCrystal(int amount)
    {
        playerCrystalCount += amount;
    }

    public void AddToCrystal()
    {
        playerCrystalInHand += 3;
    }

}
