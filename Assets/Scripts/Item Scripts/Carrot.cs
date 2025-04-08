using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Carrot : MonoBehaviour
{

    

    void Start()
    {
        
    }

    // Update is called once per frame
    
    void CollectCarrot()
    {
        GameObject.Find("Player").GetComponent<PlayerMana>().EarnMana(15);
        GameObject.Find("GameManager").GetComponent<GameManager>().Score(50);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CollectCarrot();
            Destroy(gameObject);
        }
    }
}
