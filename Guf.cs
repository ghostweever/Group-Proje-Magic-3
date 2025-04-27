using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guf : MonoBehaviour
{
    public GameObject player;
    public AudioClip[] GuppyClip;
    void Update()
    {

    }

   public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(GuppyClip[Random.Range(0, GuppyClip.Length - 1)], transform.position, 5f);
            
        }
    }


}
