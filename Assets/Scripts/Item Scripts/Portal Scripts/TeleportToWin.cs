using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToWin : MonoBehaviour
{
    public GameObject portal;

    private void Update()
    {
        ActivatePortal();
    }


    void ActivatePortal()
    {
        if (GameObject.Find("Player").GetComponent<PlayerCrystalManager>().playerCrystalCount == 9)
        {
            gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("Win");
        }
    }


}