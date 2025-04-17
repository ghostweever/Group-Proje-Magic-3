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
            if (GameObject.Find("SceneHandler").GetComponent<SceneHandler>().sceneName == "Forest Level")
            {

                SceneManager.LoadScene("Hub");

                GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().grassCompleted = true;

            }
            else if (GameObject.Find("SceneHandler").GetComponent<SceneHandler>().sceneName == "Water Level")
            {
                SceneManager.LoadScene("Hub");

                GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().waterCompleted = true;
            }
            else if (GameObject.Find("SceneHandler").GetComponent<SceneHandler>().sceneName == "Lava Level")
            {
                SceneManager.LoadScene("Hub");

                GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().lavaCompleted = true;
            }
        }
    }
}