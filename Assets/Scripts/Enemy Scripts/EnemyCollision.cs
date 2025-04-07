using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    
    private Crystal crystal;

    void Start()
    {
        crystal = GetComponent<Crystal>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Weapon")
        {
            GameObject.Find("Player").GetComponent<PlayerMana>().EarnMana(25);
            GameObject.Find("GameManager").GetComponent<GameManager>().Score(100);
            GameObject.Find("CrystalHolder").GetComponent<Crystal>().ActivateCrystal();
            Destroy(gameObject);

        }
    }


}
