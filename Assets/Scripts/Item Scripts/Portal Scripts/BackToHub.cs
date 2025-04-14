using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToHub : MonoBehaviour
{
    public GameObject portal;
    PlayerCrystalManager playerCrystalManager;
    public int completedLevel;
    private void Start()
    {
        playerCrystalManager = GetComponent<PlayerCrystalManager>();
    }

    public void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            SceneManager.LoadScene("Hub");
            GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().completedLevel++;
        }
    }
}