using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{

    public int playerLives;

    void Start()
    {
        playerLives = 3;        
    }

    public void Damage(int amount)
    {
        playerLives -= amount;

        if (playerLives <= 0)
        {
            GameObject.Find("Void").GetComponent<InGameSettings>().Death();
        }

    }

}
