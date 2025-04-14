using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackToHub : MonoBehaviour
{
    public GameObject portal;


    public void Update()
    {
        if (GameObject.Find("Player").GetComponent<PlayerCrystalManager>().playerCrystalCount == 3)
        {
            portal.gameObject.SetActive(true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("Hub");
        }
    }
}