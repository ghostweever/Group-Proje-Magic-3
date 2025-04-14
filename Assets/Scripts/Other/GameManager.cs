using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    PlayerCrystalManager playerCrystalManager;

    public int score;

    void Start()
    {
        score = 0;
        playerCrystalManager = GetComponent<PlayerCrystalManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Score(int amount)
    {
        score += amount;
    }
}
