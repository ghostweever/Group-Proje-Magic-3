using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Carrot : MonoBehaviour
{

    public AudioClip carrotClip;
    public CarrotType carrot;
    

    void Start()
    {
        
    }

    public enum CarrotType
    {
        Heal,
        Mana
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
            switch (carrot)
            {
                case CarrotType.Heal:
                    GameObject.Find("Player").GetComponent<PlayerLives>().Heal(1);
                break;

                case CarrotType.Mana:
                    GameObject.Find("Player").GetComponent<PlayerMana>().EarnMana(10);
                break;

            }

            Destroy(gameObject);
        }
    }
}
