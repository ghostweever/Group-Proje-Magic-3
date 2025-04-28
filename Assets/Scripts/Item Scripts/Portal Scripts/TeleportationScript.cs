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
    public AudioSource audioSource;

    public void Start()
    {
        portalScript = GetComponent<PortalScript>();
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
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
                    StartCoroutine(LoadScene("Level 1 Forest"));
                    break;

                case Portal.Water:
                    loadingScreen.SetActive(true);
                    StartCoroutine(LoadScene("Paul Water Level"));
                    break;

                case Portal.Lava:
                    loadingScreen.SetActive(true);
                    StartCoroutine(LoadScene("Lava Level"));
                    break;

                case Portal.Oasis:
                    loadingScreen.SetActive(true);
                    StartCoroutine(LoadScene("Cutscenes"));
                break;

                case Portal.Win:
                    loadingScreen.SetActive(true);
                    StartCoroutine(LoadScene("Win"));
                    break;

                case Portal.GrassHub:
                   if (GameObject.Find("SceneHandler").GetComponent<SceneHandler>().sceneName == "Forest Level")
                    {
                        GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().grassCompleted = true;
                    }

                    SceneManager.LoadScene("Hub");

                    break;

                case Portal.WaterHub:
                    if (GameObject.Find("SceneHandler").GetComponent<SceneHandler>().sceneName == "Water Level")
                    {
                        GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().waterCompleted = true;
                    }

                    SceneManager.LoadScene("Hub");

                    break;

                case Portal.LavaHub:
                    if (GameObject.Find("SceneHandler").GetComponent<SceneHandler>().sceneName == "Lava Level")
                    {
                        GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().lavaCompleted = true;
                    }

                    SceneManager.LoadScene("Hub");

                    break;
            }
        }
    }

    private IEnumerator LoadScene(string sceneToLoad)
    {
        audioSource.volume = 0f;
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(sceneToLoad);
    }

}
