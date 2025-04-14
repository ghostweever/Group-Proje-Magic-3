using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TeleportationScript : MonoBehaviour
{
   private PortalScript portalScript;
    public GameObject player;
    public GameObject loadingScreen;
    public GameObject portal;
    
    public void Start()
    {
        portalScript = GetComponent<PortalScript>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && GameObject.Find("PortalManager (Level 1)").GetComponent<PortalScript>().portalType == 0)
        {
            loadingScreen.SetActive(true);
            SceneManager.LoadSceneAsync("Forest Level");
            player.transform.position = new Vector3(-3.1f, 430.83f, 201.2f);


        } 

        
    }

}
