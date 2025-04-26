using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCollision : MonoBehaviour
{
    
    private Crystal crystal;
    public int whatEnemyAmI;
    public int enemyLives;
    public EnemyType enemyType;
    public NavMeshAgent agent;
    private PlayerMana playerMana;
    private PlayerLives lives;
    public GameObject player;
    private MeshRenderer enemyRenderer;
    public Material[] materials;

    void Start()
    {
        crystal = GetComponent<Crystal>();
        agent = GetComponent<NavMeshAgent>();  
        
       

        player = GameObject.FindGameObjectWithTag("Player");

        if(player != null)
        {
            playerMana = player.GetComponent<PlayerMana>();
            lives = player.GetComponent<PlayerLives>();
        }

        SetEnemyStats();
    }

    private void Update()
    {
        DestroyEnemy();
    }

    public enum EnemyType
    {
        Common,
        BossOne,
        BossTwo,
        BossThree,
        FireBuf,
        WaterBuf,
        GrassBuf,

    }

    private void SetEnemyStats()
    {
        switch (enemyType)
        {
            case EnemyType.Common:
                enemyLives = 1;
                break;
            case EnemyType.BossOne:
                enemyLives = 5;
                agent.speed = 7f;
                break;
            case EnemyType.BossTwo:
                enemyLives = 3;
                agent.speed = 10f;
                break;
            case EnemyType.BossThree:
                enemyLives = 3;
                agent.speed = 5f;
                break;
            case EnemyType.FireBuf:
                enemyLives = 1;
                agent.speed = 7;
            break;
            case EnemyType.WaterBuf:
                enemyLives = 2;
                break;
            case EnemyType.GrassBuf:
                enemyLives = 1;
                agent.speed = 10;
                break;
        }
    }

    private void DestroyEnemy()
    {
        if(enemyLives <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        switch (enemyType)
        {

            case EnemyType.Common:
                playerMana.EarnMana(15);
                break;
            case EnemyType.BossOne:
                playerMana.EarnMana(50);
                GameObject.Find("CrystalHolder").GetComponent<Crystal>().ActivateCrystal();
                break;
            case EnemyType.BossTwo:
                playerMana.EarnMana(25);
                GameObject.Find("CrystalHolder (1)").GetComponent<Crystal>().ActivateCrystal();
                break;
            case EnemyType.BossThree:
                playerMana.EarnMana(35);
                GameObject.Find("CrystalHolder (2)").GetComponent<Crystal>().ActivateCrystal();
                break;

        }

        Destroy(gameObject);

     }

    private void TakeDamage(int amount)
    {
        enemyLives -= amount;
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Weapon")
        {
            {
                TakeDamage(1);
                Debug.Log(enemyLives);
            }
        }
    }
}


        
