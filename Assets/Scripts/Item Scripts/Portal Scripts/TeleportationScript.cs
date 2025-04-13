using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TeleportationScript : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && GameObject.Find("Player").GetComponent<PlayerCrystalManager>().WinCondition())
        {
            SceneManager.LoadScene("Win");
        }
    }
}
