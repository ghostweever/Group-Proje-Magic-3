using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{

    public GameObject player;
    public GameObject spawnPos;


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.transform.position = spawnPos.transform.position;
            
        }
    }

}
