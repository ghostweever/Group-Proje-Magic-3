using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCollision : MonoBehaviour
{
    
    private Crystal crystal;
    public int whatEnemyAmI;
    public int enemyLives;
    public NavMeshAgent agent;

    void Start()
    {
        crystal = GetComponent<Crystal>();
        WhoAmI();
        agent = GetComponent<NavMeshAgent>();  
    }
    public void WhoAmI()
        //Changes enemy values
    {
        if (whatEnemyAmI == 0)
        {
            enemyLives = 1;
        }
        else if (whatEnemyAmI == 1)
        {
            enemyLives = 5;
            agent.speed = 7f;

        }
        else if (whatEnemyAmI == 2)
        {
            enemyLives = 3;
            agent.speed = 7f;
        }
        else if (whatEnemyAmI == 3)
        {
            enemyLives = 4;
            agent.speed = 5f;
        }
    }

    void EnemyLives(int amount)
        //Depending on enemy value it will reward diffferently
    {
        enemyLives -= amount;

        if (enemyLives <= 0 && whatEnemyAmI == 1)
        {
            Destroy(gameObject);
            GameObject.Find("Player").GetComponent<PlayerMana>().EarnMana(25);
            GameObject.Find("GameManager").GetComponent<GameManager>().Score(100);
            GameObject.Find("CrystalHolder").GetComponent<Crystal>().ActivateCrystal();
        } else if (enemyLives <= 0 && whatEnemyAmI == 2)
        {
            Destroy(gameObject);
            GameObject.Find("Player").GetComponent<PlayerMana>().EarnMana(25);
            GameObject.Find("GameManager").GetComponent<GameManager>().Score(100);
            GameObject.Find("CrystalHolder (1)").GetComponent<Crystal>().ActivateCrystal();
        } else if (enemyLives <= 0 && whatEnemyAmI == 3)
        {
            Destroy(gameObject);
            GameObject.Find("Player").GetComponent<PlayerMana>().EarnMana(25);
            GameObject.Find("GameManager").GetComponent<GameManager>().Score(100);
            GameObject.Find("CrystalHolder (2)").GetComponent<Crystal>().ActivateCrystal();
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Weapon")
        {

            EnemyLives(1);
            Debug.Log(enemyLives);
        }

        if (collision.tag == "Player")
        {
            GameObject.Find("Void").GetComponent<InGameSettings>().Death();
        }
    }
}


        
