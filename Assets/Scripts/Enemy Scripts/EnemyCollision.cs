using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    
    private Crystal crystal;
    public int whatEnemyAmI;
    public int enemyLives;

    void Start()
    {
        crystal = GetComponent<Crystal>();
        WhoAmI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void WhoAmI()
    {
        if (whatEnemyAmI == 0)
        {
            enemyLives = 1;
        }
        else if (whatEnemyAmI == 1)
        {
            enemyLives = 5;

        }
    }

    void EnemyLives(int amount)
    {
        enemyLives -= amount;

        if (enemyLives <= 0)
        {
            Destroy(gameObject);
            GameObject.Find("Player").GetComponent<PlayerMana>().EarnMana(25);
            GameObject.Find("GameManager").GetComponent<GameManager>().Score(100);
            GameObject.Find("CrystalHolder").GetComponent<Crystal>().ActivateCrystal();
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Weapon")
        {

            EnemyLives(1);
            Debug.Log(enemyLives);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            //GameObject.Find("Void").GetComponent<MenuButtons>().GameOver();
        }
    }
}
        
