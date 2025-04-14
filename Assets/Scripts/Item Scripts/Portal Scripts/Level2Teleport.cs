using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Teleport : MonoBehaviour
{
    public GameObject player;
    public GameObject loadingScreen;

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && GameObject.Find("PortalManager (Level 2)").GetComponent<PortalScript>().portalType == 1)
        {
            loadingScreen.SetActive(true);
            SceneManager.LoadSceneAsync("Level2");
            player.transform.position = new Vector3(0, 1, 0);
        }
    }
}