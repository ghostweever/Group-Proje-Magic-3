using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{


    public Vector3 hubPosition;
    public Vector3 forestPosition;
 

    public GameData()
    {
        hubPosition = new Vector3(0, 56.07f, 84.38647f);
        forestPosition = new Vector3(-3.1f, 430.83f, 201.2f);

    }
}
