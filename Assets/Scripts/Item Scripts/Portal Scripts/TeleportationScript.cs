using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TeleportationScript : MonoBehaviour
{
    private PortalScript portalScript;
    public GameObject player;
    public GameObject loadingScreen;
    public Portal portalType;

    public void Start()
    {
        portalScript = GetComponent<PortalScript>();

    }


    public enum Portal
    {
        Grass,
        Water,
        Lava,
        Oasis,
        Win,
        GrassHub,
        WaterHub,
        LavaHub
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            switch (portalType)
            {
                case Portal.Grass:
                    loadingScreen.SetActive(true);
                    SceneManager.LoadSceneAsync("Level 1 Forest");
                break;

                case Portal.Water:
                    loadingScreen.SetActive(true);
                    SceneManager.LoadSceneAsync("Level2");
                break;

                case Portal.Lava:
                    loadingScreen.SetActive(true);
                    SceneManager.LoadSceneAsync("Level3");
                break;

                case Portal.Oasis:
                    loadingScreen.SetActive(true);
                    SceneManager.LoadSceneAsync("Hub");
                break;

                case Portal.Win:
                    loadingScreen.SetActive(true);
                    SceneManager.LoadSceneAsync("Win");
                break;

                case Portal.GrassHub:
                   if (GameObject.Find("SceneHandler").GetComponent<SceneHandler>().sceneName == "Forest Level")
                    {
                        GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().grassCompleted = true;
                    }

                    SceneManager.LoadSceneAsync("Hub");

                break;

                case Portal.WaterHub:
                    if (GameObject.Find("SceneHandler").GetComponent<SceneHandler>().sceneName == "Water Level")
                    {
                        GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().waterCompleted = true;
                    }

                    SceneManager.LoadSceneAsync("Hub");

                break;

                case Portal.LavaHub:
                    if (GameObject.Find("SceneHandler").GetComponent<SceneHandler>().sceneName == "Lava Level")
                    {
                        GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().lavaCompleted = true;
                    }

                    SceneManager.LoadSceneAsync("Hub");

                    break;
            }
        }
    }
}
