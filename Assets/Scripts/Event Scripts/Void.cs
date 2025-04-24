using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{

    public GameObject player;
    public GameObject spawnPos;
    public GameObject transition;

    private void Start()
    {
     transition.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            player.transform.position = spawnPos.transform.position;
        }
    }
}
