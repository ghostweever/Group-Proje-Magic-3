using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] GameObject otherEnd;
    [SerializeField] GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           player.transform.position = new Vector3(otherEnd.transform.position.x + 7, otherEnd.transform.position.y, otherEnd.transform.position.z);
        }

    }
}
