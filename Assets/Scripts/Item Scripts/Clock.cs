using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{

    public AudioClip clockClip;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject.Find("Canvas").GetComponent<Timer>().remainingTime += 25;
            AudioSource.PlayClipAtPoint(clockClip, transform.position, 1);
            Destroy(gameObject);
        }
    }
}
