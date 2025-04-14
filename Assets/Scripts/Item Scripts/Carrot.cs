using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Carrot : MonoBehaviour
{

    public AudioClip carrotClip;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    
    void CollectCarrot()
    {
        GameObject.Find("Player").GetComponent<PlayerMana>().EarnMana(5);
        GameObject.Find("GameManager").GetComponent<GameManager>().Score(50);
        AudioSource.PlayClipAtPoint(carrotClip, transform.position, .7f);
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
