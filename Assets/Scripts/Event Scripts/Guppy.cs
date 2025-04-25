using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guppy : MonoBehaviour
{
    public GameObject player;
    public AudioClip[] GuppyClip;
    void Update()
    {
        
    }

    void OnTriggerEmter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(GuppyClip[Random.Range(0, GuppyClip.Length)], transform.position, 5f);
        }
    }


}
