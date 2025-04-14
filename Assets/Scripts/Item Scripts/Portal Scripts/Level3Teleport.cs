using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level3Teleport : MonoBehaviour
{
    public GameObject player;
    public GameObject loadingScreen;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && GameObject.Find("PortalManager (Level 3)").GetComponent<PortalScript>().portalType == 2)
        {
            loadingScreen.SetActive(true);
            SceneManager.LoadSceneAsync("Level3");
            player.transform.position = new Vector3(0, 1, 0);
        }
    }
}
